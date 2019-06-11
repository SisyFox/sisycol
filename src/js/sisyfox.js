const flatbuffers = require('./flatbuffers').flatbuffers;
const sisyfox = require('./sisycol_generated').sisyfox;

class Sisyfox {
    constructor(wsHost, wsPort=80) {
        this.callback = [];
        this.initCallbacks = [];
        this.defaultCallback = [];
        this.socketOpen = false;
        this.reconnections = 0;

        this.callback[sisyfox.sisycol.Payload.Error] = [function printError(response) {
            let error = response.payload(new sisyfox.sisycol.response.Error());
            console.log("SisyFox has trouble - Code #" + error.errorCode().toString());
        }];

        if (wsPort !== 80) {
            this.wsAddr = "ws://" + wsHost + ":" + wsPort.toString();
        } else {
            this.wsAddr = "ws://" + wsHost + "/wsocket";
        }

        this.createSocket();
        this.addDefaultCallbacks();
    }

    init() {
        const length = this.initCallbacks.length;
        if (this.initCallbacks.lengths === 0) {
            console.log("No init callback registered");
        } else {
            for (let index = 0; index < length; index++) {
                this.initCallbacks[index]();
            }
        }
    }

    createSocket() {
        console.log("Create Sisycol Socket...");
        const self = this;

        this.socket = new WebSocket(this.wsAddr);

        this.socket.binaryType = "arraybuffer";
        this.socket.onopen = function () {
            self.webSocketOpened();
        };
        this.socket.onclose = function () {
            self.webSocketClosed();
        };
        this.socket.onmessage = function (event) {
            self.webSocketReceived(event);
        };
    }

    reconnect() {
        const self = this;
        setTimeout(function () {self.reconnections--;}, 20000);
        this.reconnections++;
        this.createSocket();
    }

    webSocketClosed() {
        console.log("Connection to SisyFox closed.");
        if (this.socketOpen) {
            if (this.reconnections < 3) {
                this.reconnect();
            }
            this.socketOpen = false;
        }
    }

    webSocketOpened() {
        console.log("Connection to SisyFox established.");
        if (!this.reconnections) {
            this.init();
        }
        this.socketOpen = true;
    }

    webSocketReceived(event) {
        console.log("Received " + event.data.byteLength.toString() + " Bytes");
        const payload = new flatbuffers.ByteBuffer(new Uint8Array(event.data));
        this.handleResponse(sisyfox.sisycol.Root.getRootAsRoot(payload));
    }

    handleResponse(response) {
        if (this.callback[response.payloadType()] !== undefined) {
            for (let callback of this.callback[response.payloadType()]) {
                callback(response);
            }
        } else if (this.defaultCallback[response.payloadType()] === undefined) {
            console.log("No callback defined to handle this kind of response! (" + response.payloadType().toString() + ")");
        }
        if (this.defaultCallback[response.payloadType()] !== undefined) {
            this.defaultCallback[response.payloadType()](response);
        }
    }

    static getVersion(builder, high = 2, low = 0) {
        return sisyfox.sisycol.Version.createVersion(builder, high, low);
    }

    send(request) {
        const payload = new Uint8Array(request.length + 4);
        payload.set(request, 4);
        const dv = new DataView(payload.buffer, 0, 4);
        dv.setUint32(0, request.length, true);
        console.log("Transmit " + request.length.toString() + " Bytes");
        this.socket.send(payload);
    }

    prepareSend(payloadType, payload, builder) {
        sisyfox.sisycol.Root.startRoot(builder);
        sisyfox.sisycol.Root.addVersion(builder, Sisyfox.getVersion(builder));
        sisyfox.sisycol.Root.addMessageId(builder, 0);
        sisyfox.sisycol.Root.addPayloadType(builder, payloadType);
        sisyfox.sisycol.Root.addPayload(builder, payload);
        const request = sisyfox.sisycol.Root.endRoot(builder);
        builder.finish(request);
        console.log("Transmit " + builder.asUint8Array().length.toString() + " Bytes");
        this.socket.send(builder.asUint8Array());
    }

    setCallback(payloadType, func) {
        if (this.callback[payloadType] === undefined) {
            this.callback[payloadType] = [];
        }
        this.callback[payloadType].push(func);
    }

    callDefaultCallback(payloadType, response) {
        if (this.defaultCallback[payloadType] !== undefined) {
            this.defaultCallback[payloadType](response);
        }
    }

    addInitCallback(func) {
        this.initCallbacks.push(func);
    }

    addDefaultCallbacks() {
        this.defaultCallback[sisyfox.sisycol.Payload.AddUser] = function () {
            console.log("new user was created.");
        };
        this.defaultCallback[sisyfox.sisycol.Payload.AddScore] = function () {
            console.log("new score was added");
        };
        this.defaultCallback[sisyfox.sisycol.Payload.SetUser] = function () {
            console.log("changed user");
        };
        this.defaultCallback[sisyfox.sisycol.Payload.UnsetUser] = function () {
            console.log("user logged out");
        };
        this.defaultCallback[sisyfox.sisycol.Payload.SetSetting] = function (response) {
            console.log("changed setting")
        };
        this.defaultCallback[sisyfox.sisycol.Payload.Trigger] = function (response) {
            const payload = response.payload(new sisyfox.sisycol.response.Trigger());
            switch (payload.type()) {
                case sisyfox.sisycol.TriggerType.NEW_ROUND:
                    console.log("triggered new round");
                    break;
            }
        };
        this.defaultCallback[sisyfox.sisycol.Payload.GetSetting] = function (response) {
            const payload = response.payload(new sisyfox.sisycol.response.GetSetting());
            console.log("Info", "Angeforderter Wert: " + payload.value().toString());
        };
    }

    requestInfo() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.Info.startInfo(builder);
        const offset = sisyfox.sisycol.request.Info.endInfo(builder);
        this.prepareSend(sisyfox.sisycol.Payload.Info, offset, builder);
    }

    requestGetDetectedDevices() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetDetectedDevices.startGetDetectedDevices(builder);
        const offset = sisyfox.sisycol.request.GetDetectedDevices.endGetDetectedDevices(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetDetectedDevices, offset, builder);
    }

    requestAddScore(height, maxGoal, time, reason) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddScore.startAddScore(builder);
        sisyfox.sisycol.request.AddScore.addGoal(builder, height);
        sisyfox.sisycol.request.AddScore.addMaxGoal(builder, maxGoal);
        sisyfox.sisycol.request.AddScore.addTime(builder, time);
        sisyfox.sisycol.request.AddScore.addReason(builder, reason);
        const offset = sisyfox.sisycol.request.AddScore.endAddScore(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddScore, offset, builder);
    }

    requestGetScore(id) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetScore.startGetScore(builder);
        sisyfox.sisycol.request.GetScore.addId(builder, id);
        const offset = sisyfox.sisycol.request.GetScore.endGetScore(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetScore, offset, builder);
    }

    requestGetScoreRange(startId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetScoreRange.startGetScoreRange(builder);
        sisyfox.sisycol.request.GetScoreRange.addStartId(builder, startId);
        sisyfox.sisycol.request.GetScoreRange.addRange(builder, range);
        const offset = sisyfox.sisycol.request.GetScoreRange.endGetScoreRange(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetScoreRange, offset, builder);
    }

    requestGetScoreFiltered(timestampBegin, timestampEnd, startId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetScoreFiltered.startGetScoreFiltered(builder);
        sisyfox.sisycol.request.GetScoreFiltered.addTimestampBegin(builder, new flatbuffers.Long(timestampBegin, 0));
        sisyfox.sisycol.request.GetScoreFiltered.addTimestampEnd(builder, new flatbuffers.Long(timestampEnd, 0));
        sisyfox.sisycol.request.GetScoreFiltered.addStartId(builder, startId);
        sisyfox.sisycol.request.GetScoreFiltered.addRange(builder, range);
        const offset = sisyfox.sisycol.request.GetScoreFiltered.endGetScoreFiltered(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetScoreFiltered, offset, builder);
    }


    requestGetUserRange(startId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetUserRange.startGetUserRange(builder);
        sisyfox.sisycol.request.GetUserRange.addStartUid(builder, startId);
        sisyfox.sisycol.request.GetUserRange.addRange(builder, range);
        const offset = sisyfox.sisycol.request.GetUserRange.endGetUserRange(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetUserRange, offset, builder);
    }

    requestGetUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetUser.startGetUser(builder);
        sisyfox.sisycol.request.GetUser.addUId(builder, uid);
        const offset = sisyfox.sisycol.request.GetUser.endGetUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetUser, offset, builder);
    }

    requestAddUser(name, info) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        const infoString = builder.createString(info);
        sisyfox.sisycol.request.AddUser.startAddUser(builder);
        sisyfox.sisycol.request.AddUser.addName(builder, nameString);
        sisyfox.sisycol.request.AddUser.addInfo(builder, infoString);
        const offset = sisyfox.sisycol.request.AddUser.endAddUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddUser, offset, builder);
    }

    requestRemoveUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveUser.startRemoveUser(builder);
        sisyfox.sisycol.request.RemoveUser.addUid(builder, uid);
        const offset = sisyfox.sisycol.request.RemoveUser.endRemoveUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.RemoveUser, offset, builder);
    }

    requestSetUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.SetUser.startSetUser(builder);
        sisyfox.sisycol.request.SetUser.addUId(builder, uid);
        const offset = sisyfox.sisycol.request.SetUser.endSetUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.SetUser, offset, builder);
    }

    requestUnsetUser() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.UnsetUser.startUnsetUser(builder);
        const offset = sisyfox.sisycol.request.UnsetUser.endUnsetUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.UnsetUser, offset, builder);
    }

    requestGetCurrentUser() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetCurrentUser.startGetCurrentUser(builder);
        const offset = sisyfox.sisycol.request.GetCurrentUser.endGetCurrentUser(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetCurrentUser, offset, builder);
    }

    requestSetSetting(setting, value) {
        const builder = new flatbuffers.Builder();

        console.log(value);
        sisyfox.sisycol.IntSetting.startIntSetting(builder);
        sisyfox.sisycol.IntSetting.addValue(builder, value);
        const intSettingOffset = sisyfox.sisycol.IntSetting.endIntSetting(builder);

        sisyfox.sisycol.request.SetSetting.startSetSetting(builder);
        sisyfox.sisycol.request.SetSetting.addType(builder, setting);
        sisyfox.sisycol.request.SetSetting.addValueType(builder, sisyfox.sisycol.SettingValue.IntSetting);
        sisyfox.sisycol.request.SetSetting.addValue(builder, intSettingOffset);
        const offset = sisyfox.sisycol.request.SetSetting.endSetSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.SetSetting, offset, builder);
    }

    requestGetSetting(setting) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetSetting.startGetSetting(builder);
        sisyfox.sisycol.request.GetSetting.addType(builder, setting);
        const offset = sisyfox.sisycol.request.GetSetting.endGetSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetSetting, offset, builder);
    }

    requestGetSettings() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetSettings.startGetSettings(builder);
        const offset = sisyfox.sisycol.request.GetSettings.endGetSettings(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetSettings, offset, builder);
    }

    requestTrigger(value) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.Trigger.startTrigger(builder);
        sisyfox.sisycol.request.Trigger.addType(builder, value);
        const offset = sisyfox.sisycol.request.Trigger.endTrigger(builder);
        this.prepareSend(sisyfox.sisycol.Payload.Trigger, offset, builder);
    }

    requestSetLiveData(height, time, pitch) {
        const builder = new flatbuffers.Builder();
        const liveData = sisyfox.sisycol.request.LiveData.createLiveData(builder, height, time, pitch);
        sisyfox.sisycol.request.SetLiveData.startSetLiveData(builder);
        sisyfox.sisycol.request.SetLiveData.addLiveData(builder, liveData);
        const offset = sisyfox.sisycol.request.SetLiveData.endSetLiveData(builder);
        this.prepareSend(sisyfox.sisycol.Payload.SetLiveData, offset, builder);
    }

    requestAddDmxDevice(name) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        sisyfox.sisycol.request.AddDmxDevice.startAddDmxDevice(builder);
        sisyfox.sisycol.request.AddDmxDevice.addName(builder, nameString);
        const offset = sisyfox.sisycol.request.AddDmxDevice.endAddDmxDevice(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxDevice, offset, builder);
    }

    requestRemoveDmxDevice(deviceId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveDmxDevice.startRemoveDmxDevice(builder);
        sisyfox.sisycol.request.RemoveDmxDevice.addDeviceId(builder, deviceId);
        const offset = sisyfox.sisycol.request.RemoveDmxDevice.endRemoveDmxDevice(builder);
        this.prepareSend(sisyfox.sisycol.Payload.RemoveDmxDevice, offset, builder);
    }

    requestAddDmxDeviceChannel(deviceId, channel, test, norm = 0) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddDmxDeviceChannel.startAddDmxDeviceChannel(builder);
        sisyfox.sisycol.request.AddDmxDeviceChannel.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.AddDmxDeviceChannel.addChannel(builder, channel);
        sisyfox.sisycol.request.AddDmxDeviceChannel.addNorm(builder, norm);
        sisyfox.sisycol.request.AddDmxDeviceChannel.addTest(builder, test);
        const offset = sisyfox.sisycol.request.AddDmxDeviceChannel.endAddDmxDeviceChannel(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxDeviceChannel, offset, builder);
    }

    requestRemoveDmxDeviceChannel(deviceId, channelId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveDmxDeviceChannel.startRemoveDmxDeviceChannel(builder);
        sisyfox.sisycol.request.RemoveDmxDeviceChannel.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.RemoveDmxDeviceChannel.addChannelId(builder, channelId);
        const offset = sisyfox.sisycol.request.RemoveDmxDeviceChannel.endRemoveDmxDeviceChannel(builder);
        this.prepareSend(sisyfox.sisycol.Payload.RemoveDmxDeviceChannel, offset, builder);
    }

    requestAddDmxChannelRule(deviceId, channelId, type, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddDmxChannelRule.startAddDmxChannelRule(builder);
        sisyfox.sisycol.request.AddDmxChannelRule.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.AddDmxChannelRule.addChannelId(builder, channelId);
        sisyfox.sisycol.request.AddDmxChannelRule.addRuleType(builder, type);
        sisyfox.sisycol.request.AddDmxChannelRule.addOn(builder, on);
        sisyfox.sisycol.request.AddDmxChannelRule.addOff(builder, off);
        sisyfox.sisycol.request.AddDmxChannelRule.addStart(builder, start);
        sisyfox.sisycol.request.AddDmxChannelRule.addStep(builder, step);
        const offset = sisyfox.sisycol.request.AddDmxChannelRule.endAddDmxChannelRule(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxChannelRule, offset, builder);
    }

    requestRemoveDmxChannelRule(deviceId, channelId, ruleId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveDmxChannelRule.startRemoveDmxChannelRule(builder);
        sisyfox.sisycol.request.RemoveDmxChannelRule.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.RemoveDmxChannelRule.addChannelId(builder, channelId);
        sisyfox.sisycol.request.RemoveDmxChannelRule.addRuleId(builder, ruleId);
        const offset = sisyfox.sisycol.request.RemoveDmxChannelRule.endRemoveDmxChannelRule(builder);
        this.prepareSend(sisyfox.sisycol.Payload.RemoveDmxChannelRule, offset, builder);
    }

    requestAddDmxDeviceSetting(deviceId, name, type, norm = 0) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        sisyfox.sisycol.request.AddDmxDeviceSetting.startAddDmxDeviceSetting(builder);
        sisyfox.sisycol.request.AddDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.AddDmxDeviceSetting.addNorm(builder, norm);
        sisyfox.sisycol.request.AddDmxDeviceSetting.addName(builder, nameString);
        sisyfox.sisycol.request.AddDmxDeviceSetting.addSettingType(builder, type);
        const offset = sisyfox.sisycol.request.AddDmxDeviceSetting.endAddDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxDeviceSetting, offset, builder);
    }

    requestRemoveDmxDeviceSetting(deviceId, settingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveDmxDeviceSetting.startRemoveDmxDeviceSetting(builder);
        sisyfox.sisycol.request.RemoveDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.RemoveDmxDeviceSetting.addSettingId(builder, settingId);
        const offset = sisyfox.sisycol.request.RemoveDmxDeviceSetting.endRemoveDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.RemoveDmxDeviceSetting, offset, builder);
    }

    requestAddDmxRuleRangeSetting(deviceId, settingId, channelId, ruleId, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.startAddDmxRuleRangeSetting(builder);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addSettingId(builder, settingId);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addChannelId(builder, channelId);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addRuleId(builder, ruleId);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addOn(builder, on);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addOff(builder, off);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addStart(builder, start);
        sisyfox.sisycol.request.AddDmxRuleRangeSetting.addStep(builder, step);
        const offset = sisyfox.sisycol.request.AddDmxRuleRangeSetting.endAddDmxRuleRangeSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxRuleRangeSetting, offset, builder);
    }

    requestAddDmxRuleBoolSetting(deviceId, settingId, channelId, ruleId, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.startAddDmxRuleBoolSetting(builder);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addSettingId(builder, settingId);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addChannelId(builder, channelId);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addRuleId(builder, ruleId);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addOn(builder, on);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addOff(builder, off);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addStart(builder, start);
        sisyfox.sisycol.request.AddDmxRuleBoolSetting.addStep(builder, step);
        const offset = sisyfox.sisycol.request.AddDmxRuleBoolSetting.endAddDmxRuleBoolSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxRuleBoolSetting, offset, builder);
    }

    requestRemoveDmxRuleSetting(deviceId, settingId, ruleSettingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.RemoveDmxRuleSetting.startRemoveDmxRuleSetting(builder);
        sisyfox.sisycol.request.RemoveDmxRuleSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.RemoveDmxRuleSetting.addSettingId(builder, settingId);
        sisyfox.sisycol.request.RemoveDmxRuleSetting.addRuleSettingId(builder, ruleSettingId);
        const offset = sisyfox.sisycol.request.RemoveDmxRuleSetting.endRemoveDmxRuleSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddDmxRuleBoolSetting, offset, builder);
    }

    requestChangeDmxDeviceSetting(deviceId, settingId, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.ChangeDmxDeviceSettingValue.startChangeDmxDeviceSettingValue(builder);
        sisyfox.sisycol.request.ChangeDmxDeviceSettingValue.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.ChangeDmxDeviceSettingValue.addSettingId(builder, settingId);
        sisyfox.sisycol.request.ChangeDmxDeviceSettingValue.addValue(builder, value);
        const offset = sisyfox.sisycol.request.ChangeDmxDeviceSettingValue.endChangeDmxDeviceSettingValue(builder);
        this.prepareSend(sisyfox.sisycol.Payload.ChangeDmxDeviceSettingValue, offset, builder);
    }

    requestGetDmxDevice(deviceId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetDmxDevice.startGetDmxDevice(builder);
        sisyfox.sisycol.request.GetDmxDevice.addDeviceId(builder, deviceId);
        const offset = sisyfox.sisycol.request.GetDmxDevice.endGetDmxDevice(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetDmxDevice, offset, builder);
    }

    requestGetDmxDeviceRange(deviceId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetDmxDeviceRange.startGetDmxDeviceRange(builder);
        sisyfox.sisycol.request.GetDmxDeviceRange.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.GetDmxDeviceRange.addRange(builder, range);
        const offset = sisyfox.sisycol.request.GetDmxDeviceRange.endGetDmxDeviceRange(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetDmxDeviceRange, offset, builder);
    }

    requestGetDmxDeviceSetting(deviceId, settingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetDmxDeviceSetting.startGetDmxDeviceSetting(builder);
        sisyfox.sisycol.request.GetDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.GetDmxDeviceSetting.addSettingId(builder, settingId);
        const offset = sisyfox.sisycol.request.GetDmxDeviceSetting.endGetDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetDmxDeviceSetting, offset, builder);
    }

    requestGetDmxDeviceSettingRange(deviceId, settingId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetDmxDeviceSettingRange.startGetDmxDeviceSettingRange(builder);
        sisyfox.sisycol.request.GetDmxDeviceSettingRange.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.GetDmxDeviceSettingRange.addSettingId(builder, settingId);
        sisyfox.sisycol.request.GetDmxDeviceSettingRange.addRange(builder, range);
        const offset = sisyfox.sisycol.request.GetDmxDeviceSettingRange.endGetDmxDeviceSettingRange(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetDmxDeviceSettingRange, offset, builder);
    }

    requestSetDmxDeviceMode(deviceId, mode, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.SetDmxDeviceMode.startSetDmxDeviceMode(builder);
        sisyfox.sisycol.request.SetDmxDeviceMode.addDeviceId(builder, deviceId);
        sisyfox.sisycol.request.SetDmxDeviceMode.addMode(builder, mode);
        sisyfox.sisycol.request.SetDmxDeviceMode.addValue(builder, value);
        const offset = sisyfox.sisycol.request.SetDmxDeviceMode.endSetDmxDeviceMode(builder);
        this.prepareSend(sisyfox.sisycol.Payload.SetDmxDeviceMode, offset, builder);
    }

    requestGetLiveData() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.GetLiveData.startGetLiveData(builder);
        const offset = sisyfox.sisycol.request.GetLiveData.endGetLiveData(builder);
        this.prepareSend(sisyfox.sisycol.Payload.GetLiveData, offset, builder);
    }

    requestResetDmxDevices() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.ResetDmxConfig.startResetDmxConfig(builder);
        const offset = sisyfox.sisycol.request.ResetDmxConfig.endResetDmxConfig(builder);
        this.prepareSend(sisyfox.sisycol.Payload.ResetDmxConfig, offset, builder);
    }

    requestSuspendSystem() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.SuspendSystem.startSuspendSystem(builder);
        const offset = sisyfox.sisycol.request.SuspendSystem.endSuspendSystem(builder);
        this.prepareSend(sisyfox.sisycol.Payload.SuspendSystem, offset, builder);
    }

    requestChangeRemoteMultiplayerSetting(deviceIp, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.ChangeRemoteMultiplayerSetting.startChangeRemoteMultiplayerSetting(builder);
        sisyfox.sisycol.request.ChangeRemoteMultiplayerSetting.addIp(builder, deviceIp);
        sisyfox.sisycol.request.ChangeRemoteMultiplayerSetting.addValue(builder, value);
        const offset = sisyfox.sisycol.request.ChangeRemoteMultiplayerSetting.endChangeRemoteMultiplayerSetting(builder);
        this.prepareSend(sisyfox.sisycol.Payload.ChangeRemoteMultiplayerSetting, offset, builder);
    }
}

this.sisyfox = Sisyfox;
this.sisycol = sisyfox.sisycol;
