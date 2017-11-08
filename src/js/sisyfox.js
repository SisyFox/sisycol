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
            let error = sisyfox.sisycol.payload(new sisyfox.sisycol.response.Error());
            console.log("SisyFox has trouble - Code #" + error.err().toString());
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
            const payload = response.payload(new sisyfox.sisycol.response.SetSetting());
            switch (payload.type()) {
                case sisyfox.sisycol.SettingType.SPAWN_POINT:
                    console.log("spawn point changed");
                    break;
                case sisyfox.response.SettingType.PITCH_SENSITIVITY:
                    notification.add("Info", "Steigungs-Empfindlichkeit wurde auf " +
                        Math.round(payload.value() / 2.55).toString() + "% geändert");
                    break;
                case sisyfox.response.SettingType.DIRECTION_HELPER:
                    if (payload.value()) {
                        notification.add("Info", "Richtungshilfe wurde aktiviert");
                    } else {

                        notification.add("Info", "Richtungshilfe wurde deaktiviert");
                    }
                    break;
                case sisyfox.response.SettingType.EVENT_PROBABILITY:
                    notification.add("Info", "Event-Wahrscheinlichkeit wurde auf " +
                        Math.round(payload.value() / 2.55).toString() + "% geändert");
                    break;
                case sisyfox.response.SettingType.MOUSE_SENSITIVITY:
                    notification.add("Info", "Empfindlichkeit des Balls wurde auf " +
                        Math.round(payload.value() / 2.55).toString() + "% geändert");
                    break;
                case sisyfox.response.SettingType.COMPETITION_MODE:
                    if (payload.value()) {
                        notification.add("Info", "Highscore Modus wurde aktiviert");
                    } else {
                        notification.add("Info", "Highscore Modus wurde deaktiviert");
                    }
                    break;
                case sisyfox.response.SettingType.TREE_COLLIDER:
                    if (payload.value()) {
                        notification.add("Info", "Baum-Collider wurde aktiviert");
                    } else {
                        notification.add("Info", "Baum-Collider wurde deaktiviert");
                    }
                    break;
                case sisyfox.response.SettingType.GAME_MODE:
                    notification.add("Info", "Spielmodus wurde geändert");
                    break;
            }
        };
        this.defaultCallback[sisyfox.sisycol.Payload.Trigger] = function (response) {
            const payload = response.payload(new sisyfox.sisycol.response.Trigger());
            switch (payload.type()) {
                case sisyfox.sisycol.TriggerType.NEW_ROUND:
                    console.log("triggered new round")
                    break;
            }
        };
        this.defaultCallback[sisyfox.sisycol.Payload.GetSetting] = function (response) {
            const payload = response.payload(new sisyfox.sisycol.response.GetSetting());
            notification.add("Info", "Angeforderter Wert: " + payload.value().toString());
        };
    }

    requestInfo() {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.Info.startInfo(builder);
        const offset = sisyfox.sisycol.request.Info.endInfo(builder);
        this.prepareSend(sisyfox.sisycol.Payload.Info, offset, builder);
    }

    requestAddScore(height, time) {
        const builder = new flatbuffers.Builder();
        sisyfox.sisycol.request.AddScore.startAddScore(builder);
        sisyfox.sisycol.request.AddScore.addHeight(builder, height);
        sisyfox.sisycol.request.AddScore.addTime(builder, time);
        const offset = sisyfox.sisycol.request.AddScore.endAddScore(builder);
        this.prepareSend(sisyfox.sisycol.Payload.AddScore, offset, builder);
    }

    requestGetScore(id) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetScore.startGetScore(builder);
        sisyfox.request.GetScore.addId(builder, id);
        const offset = sisyfox.request.GetScore.endGetScore(builder);
        this.prepareSend(sisyfox.request.Payload.GetScore, offset, builder);
    }

    requestGetScoreRange(startId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetScoreRange.startGetScoreRange(builder);
        sisyfox.request.GetScoreRange.addStartId(builder, startId);
        sisyfox.request.GetScoreRange.addRange(builder, range);
        const offset = sisyfox.request.GetScoreRange.endGetScoreRange(builder);
        this.prepareSend(sisyfox.request.Payload.GetScoreRange, offset, builder);
    }

    requestGetUserRange(startId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetUserRange.startGetUserRange(builder);
        sisyfox.request.GetUserRange.addStartUid(builder, startId);
        sisyfox.request.GetUserRange.addRange(builder, range);
        const offset = sisyfox.request.GetUserRange.endGetUserRange(builder);
        this.prepareSend(sisyfox.request.Payload.GetUserRange, offset, builder);
    }

    requestGetUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetUser.startGetUser(builder);
        sisyfox.request.GetUser.addUId(builder, uid);
        const offset = sisyfox.request.GetUser.endGetUser(builder);
        this.prepareSend(sisyfox.request.Payload.GetUser, offset, builder);
    }

    requestAddUser(name) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        sisyfox.request.AddUser.startAddUser(builder);
        sisyfox.request.AddUser.addName(builder, nameString);
        const offset = sisyfox.request.AddUser.endAddUser(builder);
        this.prepareSend(sisyfox.request.Payload.AddUser, offset, builder);
    }

    requestRemoveUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveUser.startRemoveUser(builder);
        sisyfox.request.RemoveUser.addUid(builder, uid);
        const offset = sisyfox.request.RemoveUser.endRemoveUser(builder);
        this.prepareSend(sisyfox.request.Payload.RemoveUser, offset, builder);
    }

    requestSetUser(uid) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.SetUser.startSetUser(builder);
        sisyfox.request.SetUser.addUId(builder, uid);
        const offset = sisyfox.request.SetUser.endSetUser(builder);
        this.prepareSend(sisyfox.request.Payload.SetUser, offset, builder);
    }

    requestUnsetUser() {
        const builder = new flatbuffers.Builder();
        sisyfox.request.UnsetUser.startUnsetUser(builder);
        const offset = sisyfox.request.UnsetUser.endUnsetUser(builder);
        this.prepareSend(sisyfox.request.Payload.UnsetUser, offset, builder);
    }

    requestGetCurrentUser() {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetCurrentUser.startGetCurrentUser(builder);
        const offset = sisyfox.request.GetCurrentUser.endGetCurrentUser(builder);
        this.prepareSend(sisyfox.request.Payload.GetCurrentUser, offset, builder);
    }

    requestSetSetting(setting, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.SetSetting.startSetSetting(builder);
        sisyfox.request.SetSetting.addType(builder, setting);
        sisyfox.request.SetSetting.addValue(builder, value);
        const offset = sisyfox.request.SetSetting.endSetSetting(builder);
        this.prepareSend(sisyfox.request.Payload.SetSetting, offset, builder);
    }

    requestGetSetting(setting) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetSetting.startGetSetting(builder);
        sisyfox.request.GetSetting.addType(builder, setting);
        const offset = sisyfox.request.GetSetting.endGetSetting(builder);
        this.prepareSend(sisyfox.request.Payload.GetSetting, offset, builder);
    }

    requestGetSettings() {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetSettings.startGetSettings(builder);
        const offset = sisyfox.request.GetSettings.endGetSettings(builder);
        this.prepareSend(sisyfox.request.Payload.GetSettings, offset, builder);
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
        const liveData = sisyfox.request.LiveData.createLiveData(builder, height, time, pitch);
        sisyfox.request.SetLiveData.startSetLiveData(builder);
        sisyfox.request.SetLiveData.addLiveData(builder, liveData);
        const offset = sisyfox.request.SetLiveData.endSetLiveData(builder);
        this.prepareSend(sisyfox.request.Payload.SetLiveData, offset, builder);
    }

    requestAddDmxDevice(name) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        sisyfox.request.AddDmxDevice.startAddDmxDevice(builder);
        sisyfox.request.AddDmxDevice.addName(builder, nameString);
        const offset = sisyfox.request.AddDmxDevice.endAddDmxDevice(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxDevice, offset, builder);
    }

    requestRemoveDmxDevice(deviceId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveDmxDevice.startRemoveDmxDevice(builder);
        sisyfox.request.RemoveDmxDevice.addDeviceId(builder, deviceId);
        const offset = sisyfox.request.RemoveDmxDevice.endRemoveDmxDevice(builder);
        this.prepareSend(sisyfox.request.Payload.RemoveDmxDevice, offset, builder);
    }

    requestAddDmxDeviceChannel(deviceId, channel, test, norm = 0) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.AddDmxDeviceChannel.startAddDmxDeviceChannel(builder);
        sisyfox.request.AddDmxDeviceChannel.addDeviceId(builder, deviceId);
        sisyfox.request.AddDmxDeviceChannel.addChannel(builder, channel);
        sisyfox.request.AddDmxDeviceChannel.addNorm(builder, norm);
        sisyfox.request.AddDmxDeviceChannel.addTest(builder, test);
        const offset = sisyfox.request.AddDmxDeviceChannel.endAddDmxDeviceChannel(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxDeviceChannel, offset, builder);
    }

    requestRemoveDmxDeviceChannel(deviceId, channelId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveDmxDeviceChannel.startRemoveDmxDeviceChannel(builder);
        sisyfox.request.RemoveDmxDeviceChannel.addDeviceId(builder, deviceId);
        sisyfox.request.RemoveDmxDeviceChannel.addChannelId(builder, channelId);
        const offset = sisyfox.request.RemoveDmxDeviceChannel.endRemoveDmxDeviceChannel(builder);
        this.prepareSend(sisyfox.request.Payload.RemoveDmxDeviceChannel, offset, builder);
    }

    requestAddDmxChannelRule(deviceId, channelId, type, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.AddDmxChannelRule.startAddDmxChannelRule(builder);
        sisyfox.request.AddDmxChannelRule.addDeviceId(builder, deviceId);
        sisyfox.request.AddDmxChannelRule.addChannelId(builder, channelId);
        sisyfox.request.AddDmxChannelRule.addRuleType(builder, type);
        sisyfox.request.AddDmxChannelRule.addOn(builder, on);
        sisyfox.request.AddDmxChannelRule.addOff(builder, off);
        sisyfox.request.AddDmxChannelRule.addStart(builder, start);
        sisyfox.request.AddDmxChannelRule.addStep(builder, step);
        const offset = sisyfox.request.AddDmxChannelRule.endAddDmxChannelRule(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxChannelRule, offset, builder);
    }

    requestRemoveDmxChannelRule(deviceId, channelId, ruleId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveDmxChannelRule.startRemoveDmxChannelRule(builder);
        sisyfox.request.RemoveDmxChannelRule.addDeviceId(builder, deviceId);
        sisyfox.request.RemoveDmxChannelRule.addChannelId(builder, channelId);
        sisyfox.request.RemoveDmxChannelRule.addRuleId(builder, ruleId);
        const offset = sisyfox.request.RemoveDmxChannelRule.endRemoveDmxChannelRule(builder);
        this.prepareSend(sisyfox.request.Payload.RemoveDmxChannelRule, offset, builder);
    }

    requestAddDmxDeviceSetting(deviceId, name, type, norm = 0) {
        const builder = new flatbuffers.Builder();
        const nameString = builder.createString(name);
        sisyfox.request.AddDmxDeviceSetting.startAddDmxDeviceSetting(builder);
        sisyfox.request.AddDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.request.AddDmxDeviceSetting.addNorm(builder, norm);
        sisyfox.request.AddDmxDeviceSetting.addName(builder, nameString);
        sisyfox.request.AddDmxDeviceSetting.addSettingType(builder, type);
        const offset = sisyfox.request.AddDmxDeviceSetting.endAddDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxDeviceSetting, offset, builder);
    }

    requestRemoveDmxDeviceSetting(deviceId, settingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveDmxDeviceSetting.startRemoveDmxDeviceSetting(builder);
        sisyfox.request.RemoveDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.request.RemoveDmxDeviceSetting.addSettingId(builder, settingId);
        const offset = sisyfox.request.RemoveDmxDeviceSetting.endRemoveDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.request.Payload.RemoveDmxDeviceSetting, offset, builder);
    }

    requestAddDmxRuleRangeSetting(deviceId, settingId, channelId, ruleId, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.AddDmxRuleRangeSetting.startAddDmxRuleRangeSetting(builder);
        sisyfox.request.AddDmxRuleRangeSetting.addDeviceId(builder, deviceId);
        sisyfox.request.AddDmxRuleRangeSetting.addSettingId(builder, settingId);
        sisyfox.request.AddDmxRuleRangeSetting.addChannelId(builder, channelId);
        sisyfox.request.AddDmxRuleRangeSetting.addRuleId(builder, ruleId);
        sisyfox.request.AddDmxRuleRangeSetting.addOn(builder, on);
        sisyfox.request.AddDmxRuleRangeSetting.addOff(builder, off);
        sisyfox.request.AddDmxRuleRangeSetting.addStart(builder, start);
        sisyfox.request.AddDmxRuleRangeSetting.addStep(builder, step);
        const offset = sisyfox.request.AddDmxRuleRangeSetting.endAddDmxRuleRangeSetting(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxRuleRangeSetting, offset, builder);
    }

    requestAddDmxRuleBoolSetting(deviceId, settingId, channelId, ruleId, on, off, start, step) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.AddDmxRuleBoolSetting.startAddDmxRuleBoolSetting(builder);
        sisyfox.request.AddDmxRuleBoolSetting.addDeviceId(builder, deviceId);
        sisyfox.request.AddDmxRuleBoolSetting.addSettingId(builder, settingId);
        sisyfox.request.AddDmxRuleBoolSetting.addChannelId(builder, channelId);
        sisyfox.request.AddDmxRuleBoolSetting.addRuleId(builder, ruleId);
        sisyfox.request.AddDmxRuleBoolSetting.addOn(builder, on);
        sisyfox.request.AddDmxRuleBoolSetting.addOff(builder, off);
        sisyfox.request.AddDmxRuleBoolSetting.addStart(builder, start);
        sisyfox.request.AddDmxRuleBoolSetting.addStep(builder, step);
        const offset = sisyfox.request.AddDmxRuleBoolSetting.endAddDmxRuleBoolSetting(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxRuleBoolSetting, offset, builder);
    }

    requestRemoveDmxRuleSetting(deviceId, settingId, ruleSettingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.RemoveDmxRuleSetting.startRemoveDmxRuleSetting(builder);
        sisyfox.request.RemoveDmxRuleSetting.addDeviceId(builder, deviceId);
        sisyfox.request.RemoveDmxRuleSetting.addSettingId(builder, settingId);
        sisyfox.request.RemoveDmxRuleSetting.addRuleSettingId(builder, ruleSettingId);
        const offset = sisyfox.request.RemoveDmxRuleSetting.endRemoveDmxRuleSetting(builder);
        this.prepareSend(sisyfox.request.Payload.AddDmxRuleBoolSetting, offset, builder);
    }

    requestChangeDmxDeviceSetting(deviceId, settingId, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.ChangeDmxDeviceSettingValue.startChangeDmxDeviceSettingValue(builder);
        sisyfox.request.ChangeDmxDeviceSettingValue.addDeviceId(builder, deviceId);
        sisyfox.request.ChangeDmxDeviceSettingValue.addSettingId(builder, settingId);
        sisyfox.request.ChangeDmxDeviceSettingValue.addValue(builder, value);
        const offset = sisyfox.request.ChangeDmxDeviceSettingValue.endChangeDmxDeviceSettingValue(builder);
        this.prepareSend(sisyfox.request.Payload.ChangeDmxDeviceSettingValue, offset, builder);
    }

    requestGetDmxDevice(deviceId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetDmxDevice.startGetDmxDevice(builder);
        sisyfox.request.GetDmxDevice.addDeviceId(builder, deviceId);
        const offset = sisyfox.request.GetDmxDevice.endGetDmxDevice(builder);
        this.prepareSend(sisyfox.request.Payload.GetDmxDevice, offset, builder);
    }

    requestGetDmxDeviceRange(deviceId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetDmxDeviceRange.startGetDmxDeviceRange(builder);
        sisyfox.request.GetDmxDeviceRange.addDeviceId(builder, deviceId);
        sisyfox.request.GetDmxDeviceRange.addRange(builder, range);
        const offset = sisyfox.request.GetDmxDeviceRange.endGetDmxDeviceRange(builder);
        this.prepareSend(sisyfox.request.Payload.GetDmxDeviceRange, offset, builder);
    }

    requestGetDmxDeviceSetting(deviceId, settingId) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetDmxDeviceSetting.startGetDmxDeviceSetting(builder);
        sisyfox.request.GetDmxDeviceSetting.addDeviceId(builder, deviceId);
        sisyfox.request.GetDmxDeviceSetting.addSettingId(builder, settingId);
        const offset = sisyfox.request.GetDmxDeviceSetting.endGetDmxDeviceSetting(builder);
        this.prepareSend(sisyfox.request.Payload.GetDmxDeviceSetting, offset, builder);
    }

    requestGetDmxDeviceSettingRange(deviceId, settingId, range) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetDmxDeviceSettingRange.startGetDmxDeviceSettingRange(builder);
        sisyfox.request.GetDmxDeviceSettingRange.addDeviceId(builder, deviceId);
        sisyfox.request.GetDmxDeviceSettingRange.addSettingId(builder, settingId);
        sisyfox.request.GetDmxDeviceSettingRange.addRange(builder, range);
        const offset = sisyfox.request.GetDmxDeviceSettingRange.endGetDmxDeviceSettingRange(builder);
        this.prepareSend(sisyfox.request.Payload.GetDmxDeviceSettingRange, offset, builder);
    }

    requestSetDmxDeviceMode(deviceId, mode, value) {
        const builder = new flatbuffers.Builder();
        sisyfox.request.SetDmxDeviceMode.startSetDmxDeviceMode(builder);
        sisyfox.request.SetDmxDeviceMode.addDeviceId(builder, deviceId);
        sisyfox.request.SetDmxDeviceMode.addMode(builder, mode);
        sisyfox.request.SetDmxDeviceMode.addValue(builder, value);
        const offset = sisyfox.request.SetDmxDeviceMode.endSetDmxDeviceMode(builder);
        this.prepareSend(sisyfox.request.Payload.SetDmxDeviceMode, offset, builder);
    }

    requestGetLiveData() {
        const builder = new flatbuffers.Builder();
        sisyfox.request.GetLiveData.startGetLiveData(builder);
        const offset = sisyfox.request.GetLiveData.endGetLiveData(builder);
        this.prepareSend(sisyfox.request.Payload.GetLiveData, offset, builder);
    }
}

this.sisyfox = Sisyfox;
this.sisycol = sisyfox.sisycol;
