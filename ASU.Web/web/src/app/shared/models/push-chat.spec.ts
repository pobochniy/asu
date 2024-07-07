import { PushChatModel } from "./push-chat.model";

describe('chat text parser', () => {

  it('simple text', () => {
    // Arrange
    const text = "hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat).toEqual(undefined);
    expect(res.to).toEqual(undefined);
    expect(res.message).toEqual("hello!!");
  });

  it('to [bla1] hello!!', () => {
    // Arrange
    const text = "to [bla1] hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat).toEqual(undefined);
    expect(res.to!.length).toEqual(1);
    expect(res.to![0]).toEqual('bla1');
    expect(res.message).toEqual("hello!!");
  });

  it('to [bla1, bla2] hello!!', () => {
    // Arrange
    const text = "to [bla1, bla2] hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat).toEqual(undefined);
    expect(res.to!.length).toEqual(2);
    expect(res.to![0]).toEqual('bla1');
    expect(res.to![1]).toEqual('bla2');
    expect(res.message).toEqual("hello!!");
  });

  it('to [login1, login two] private [login3] hello!!', () => {
    // Arrange
    const text = "to [login1, login two ] private [login3] hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat!.length).toEqual(1);
    expect(res.privat![0]).toEqual('login3');

    expect(res.to!.length).toEqual(2);
    expect(res.to![0]).toEqual('login1');
    expect(res.to![1]).toEqual('login two');

    expect(res.message).toEqual("hello!!");
  });

  it('to [login1, login two] private [login3] to [login4] hello!!', () => {
    // Arrange
    const text = "to [login1, login two ] private [login3] to [login4] hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat!.length).toEqual(1);
    expect(res.privat![0]).toEqual('login3');

    expect(res.to!.length).toEqual(3);
    expect(res.to![0]).toEqual('login1');
    expect(res.to![1]).toEqual('login two');
    expect(res.to![2]).toEqual('login4');

    expect(res.message).toEqual("hello!!");
  });


  it('other text private [login3] to [ login1, login two]  private [login4] hello!!', () => {
    // Arrange
    const text = "other text private [login3] to [ login1, login two]  private [login4] hello!!";

    // Act
    const res = new PushChatModel(text);

    // Assert
    expect(res.privat!.length).toEqual(2);
    expect(res.privat![0]).toEqual('login3');
    expect(res.privat![1]).toEqual('login4');

    expect(res.to!.length).toEqual(2);
    expect(res.to![0]).toEqual('login1');
    expect(res.to![1]).toEqual('login two');

    expect(res.message).toEqual("other text     hello!!"); // да, тут вонючие пробелы, но допускаю
  });
})
