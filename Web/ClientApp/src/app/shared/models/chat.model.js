"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
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
        return _super.call(this, "") || this;
    }
    ChatModel.prototype.getTime = function () {
        var result = "";
        if (this.Id) {
            debugger;
            result = new Date(parseInt(this.Id)).toLocaleTimeString();
        }
        else
            result = new Date().toLocaleTimeString();
        return result;
    };
    return ChatModel;
}(push_chat_model_1.PushChatModel));
exports.ChatModel = ChatModel;
//# sourceMappingURL=chat.model.js.map