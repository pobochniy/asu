"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var push_chat_model_1 = require("./push-chat.model");
var ChatModel = /** @class */ (function (_super) {
    __extends(ChatModel, _super);
    function ChatModel() {
        var _this = _super.call(this, "") || this;
        _this.time = new Date().toLocaleTimeString();
        return _this;
    }
    ChatModel.prototype.toAsString = function (needPrefix) {
        var to = "";
        var prefix = "";
        if (needPrefix)
            prefix = "to ";
        if (this.to.length > 0) {
            to = prefix + "[";
            this.to.forEach(function (value) {
                to += value + ", ";
            });
            to = to.substring(0, to.length - 2);
            to += "]";
        }
        return to;
    };
    ChatModel.prototype.privatAsString = function (needPrefix) {
        var privat = "";
        var prefix = "";
        if (needPrefix)
            prefix = "private ";
        if (this.privat.length > 0) {
            privat = prefix + "[";
            this.privat.forEach(function (value) {
                privat += value + ", ";
            });
            privat = privat.substring(0, privat.length - 2);
            privat += "]";
        }
        return privat;
    };
    return ChatModel;
}(push_chat_model_1.PushChatModel));
exports.ChatModel = ChatModel;
//# sourceMappingURL=chat.model.js.map