const connection = new signalR.HubConnectionBuilder()
    .withUrl("/counterHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.assert(connection.state === signalR.HubConnectionState.Connected);
        console.log("SignalR Connected.");
    } catch (err) {
        console.assert(connection.state === signalR.HubConnectionState.Disconnected);
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(start);

// Start the connection.
start();

//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/counterHub")
//    .withAutomaticReconnect()
//    .build()

connection.onreconnecting(error => {
    console.assert(connection.state === signalR.HubConnectionState.Reconnecting);

    document.getElementById("messageInput").disabled = true;

    const li = document.createElement("li");
    li.textContent = `Connection lost due to error "${error}". Reconnecting.`;
    console.log('Connection lost due to error '+ error +'. Reconnecting.')
    document.getElementById("messagesList").appendChild(li);
});

connection.onreconnected(connectionId => {
    console.assert(connection.state === signalR.HubConnectionState.Connected);

    document.getElementById("messageInput").disabled = false;

    const li = document.createElement("li");
    li.textContent = `Connection reestablished. Connected with connectionId "${connectionId}".`;
    console.log('Connection reestablished. Connected with connectionId ' +  connectionId +'.')
    document.getElementById("messagesList").appendChild(li);
}); 

connection.onclose(error => {
    console.assert(connection.state === signalR.HubConnectionState.Disconnected);

    document.getElementById("messageInput").disabled = true;

    const li = document.createElement("li");
    li.textContent = `Connection closed due to error "${error}". Try refreshing this page to restart the connection.`;
    console.log(error);
    console.log('Connection closed due to error');
    document.getElementById("messagesList").appendChild(li);
});