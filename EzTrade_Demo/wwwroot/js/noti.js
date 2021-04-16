"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/notiHub").build();


////Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("NotiMessage", function ( priceList) {
//    var msg = priceList.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var encodedMsg =   "Nong says " + msg;
//    var li = document.createElement("li");
//    li.textContent = encodedMsg;
//    document.getElementById("messagesList").appendChild(li);
//});

//connection.start().then(function () {
//    console.log('Connection started!')
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var priceList = {
//        Price_TC : document.getElementById("priceTC").value,
//        Price_Tran : document.getElementById("priceTran").value,
//        Price_San : document.getElementById("priceSan").value,
//        G3_Buy : document.getElementById("g3Buy").value,
//        KL3_Buy : document.getElementById("KL3Buy").value,
//        G2_Buy : document.getElementById("g2Buy").value,
//        KL2_Buy : document.getElementById("KL2Buy").value,
//        G1_Buy : document.getElementById("g1Buy").value,
//        KL1_Buy : document.getElementById("KL1Buy").value,
//        Price_OrderExecution : document.getElementById("priceOrder").value,
//        KL_OrderExecution : document.getElementById("KLOrder").value,
//        G1_Sell : document.getElementById("g1Sell").value,
//        KL1_Sell : document.getElementById("KL1Sell").value,
//        G2_Sell : document.getElementById("g2Sell").value,
//        KL2_Sell : document.getElementById("KL2Sell").value,
//        G3_Sell : document.getElementById("g3Sell").value,
//        KL3_Sell : document.getElementById("KL3Sell").value,
//        TotalKL : document.getElementById("totalKL").value,
//        OpenDoor : document.getElementById("openDoor").value,
//        Tallest : document.getElementById("tallest").value,
//        Lowest : document.getElementById("lowest").value,
//        NNBuy : document.getElementById("nnbuy").value,
//        NNSell : document.getElementById("nnsell").value,
//        Room_Left : document.getElementById("room").value
//    }

//    connection.invoke("SendNoti", JSON.stringify( priceList)).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});


//test group
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/MessageHub")
    .build();
connection.start()
    .catch(err => alert(err.toString()));

$(document).ready(function () {
    $("#btnPrivateGroup").click(function (e) {
        connection.invoke('JoinGroup', "PrivateGroup");
        e.preventDefault();
    });
});
$(document).ready(function () {
    $("#btnSend").click(function (e) {
        let message = $('#messagebox').val();
        let sender = $('#senderUId').text();
        $('#messagebox').val('');

        connection.invoke('SendMessageToGroup','PrivateGroup', sender, message);

        e.preventDefault();
    });
});

$(document).ready(function () {
    $("#btnSend").click(function (e) {
        let message = $('#messagebox').val();
        let sender = $('#senderUId').text();
        $('#messagebox').val('');
        connection.invoke('SendMessage', sender, message);
        e.preventDefault();
    });
});
function appendLine(uid, message) {
    let nameElement = document.createElement('strong');
    nameElement.innerText = `${uid}:`;
    let msgElement = document.createElement('em');
    msgElement.innerText = ` ${message}`;
    let li = document.createElement('li');
    li.appendChild(nameElement);
    li.appendChild(msgElement);
    $('#messageList').append(li);
};

connection.on('UserConnected', (ConnectionId) => {
    let _message = " Connected " + ConnectionId;
    let sender = $('#senderUId').text();
    appendLine(sender, _message);
});
connection.on('UserDisconnected', (ConnectionId) => {
    let _message = " Disconnected " + ConnectionId;
    let sender = $('#senderUId').text();
    appendLine(sender, _message);
})

//Test group part 2
//var connection = new signalR.HubConnectionBuilder()
//   .withUrl("/MessageHub")
//    .build();
//connection.start().catch(function (err) {
//    return console.error(err.toString());
//});

//connection.on("ReceveiMessage", function (message) {
//    console.log(message)
//    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//    var div = document.createElement("div");
//    div.innerHTML = "User says : " +  msg + "<hr/>";
//    document.getElementById("messages").appendChild(div);
    
//});

//connection.on('UserConnected', function (connectionId) {
//    var groupElement = document.getElementById("group");
//    var option = document.createElement("option");
//    option.text = connectionId;
//    option.value = connectionId;
//    groupElement.add(option);
//});
//connection.on('UserDisconnected', function (connectionId) {
//    var groupElement = document.getElementById("group");
//    for (var i = 0; i < groupElement.length; i++) {
//        if (groupElement.option[i].value === connectionId) {
//            groupElement.remove(i);
//        }
//    }
//})

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var message = document.getElementById("message").value;
//    var groupElement = document.getElementById("group");
//    var groupValue = groupElement.options[groupElement.selectedIndex].value;

//    if (groupValue === "All" || groupValue === "My Selft") {
//        var method = groupValue === "All" ? "SendMessageToAll" : "SendMessageToCaller";
//        connection.invoke(method, message).catch(function (err) {
//            return console.error(err.toString());
//        });
//    } else if (groupValue === "Private Group") {
//        connection.invoke("SendMessageToGroup", "PrivateGroup", message).catch(function (err) {
//            return console.error(err.toString());
//        });
//    } else {
//        connection.invoke("SendMessageToUser", groupValue, message).catch(function (err) {
//            return console.error(err.toString());
//        });
//    }
//    event.preventDefault();
//});

//document.getElementById("joinGroup").addEventListener("click", function (event) {
//    connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
//        return console.error(err.toString());
//    });
//    console.log('join group')
//    event.preventDefault();
//})