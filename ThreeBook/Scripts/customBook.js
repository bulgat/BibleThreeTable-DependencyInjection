
const promise1 = Promise.resolve(3);
const promise2 = 42;
const promise3 = new Promise((resolve, reject) => {
    setTimeout(resolve, 2000, '100');
});
console.log("========" );
Promise.all([promise1, promise2, promise3]).then((values) => {
    console.log("values =", values);
    console.log("GGGGGGGGG = ", (values[2]+999));
}); 
let socket0 = new WebSocket("ws://javascript.info");
console.log("===== socket =", socket0);

let socket = new WebSocket("wss://javascript.info/article/websocket/demo/hello");

socket.onopen = function (e) {
    console.log("[open] Connection established");
    console.log("Sending to server");
    socket.send("My name is John");
};

socket.onmessage = function (event) {
    console.log(`[message] Data received from server: ${event.data}`);
};

socket.onclose = function (event) {
    if (event.wasClean) {
        console.log(`[close] Connection closed cleanly, code=${event.code} reason=${event.reason}`);
    } else {
        // e.g. server process killed or network down
        // event.code is usually 1006 in this case
        console.log('[close] Connection died');
    }
};

socket.onerror = function (error) {
    console.log(`[error]`);
};