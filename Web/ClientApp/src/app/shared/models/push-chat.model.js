"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var util_1 = require("util");
var PushChatModel = /** @class */ (function () {
    function PushChatModel(text) {
        this.message = text;
        while (this.fillToArray()) { }
        ;
        while (this.fillPrivateArray()) { }
        ;
        this.message = this.message.trim();
    }
    PushChatModel.prototype.fillToArray = function () {
        var exist = /to \[(.*?)\]/i.exec(this.message);
        if (exist) {
            if (this.to === undefined)
                this.to = [];
            this.to = this.to.concat(exist[1].split(',').map(function (item) { return item.trim(); }));
            this.message = this.message.replace(exist[0], '');
        }
        return !util_1.isNull(exist);
    };
    PushChatModel.prototype.fillPrivateArray = function () {
        var exist = /private \[(.*?)\]/i.exec(this.message);
        if (exist) {
            if (this.privat === undefined)
                this.privat = [];
            this.privat = this.privat.concat(exist[1].split(',').map(function (item) { return item.trim(); }));
            this.message = this.message.replace(exist[0], '');
        }
        return !util_1.isNull(exist);
    };
    PushChatModel.prototype.toString = function () {
        var result = "";
        if (this.privat)
            if (this.privat.length > 0)
                result += "private [" + this.privat.join(', ') + "] ";
        if (this.to)
            if (this.to.length > 0)
                result += "to [" + this.to.join(', ') + "] ";
        if (this.message)
            result += this.message;
        return result;
    };
    return PushChatModel;
}());
exports.PushChatModel = PushChatModel;
//# sourceMappingURL=push-chat.model.js.map