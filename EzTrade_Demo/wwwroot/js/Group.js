"use strict";



    const postlist = document.querySelector('#posts-list');
    const addPostForm = document.querySelector('.add-post-form');

    const IdValue = document.getElementById('id-value');
    const TCValue = document.getElementById('tc-value');
    const TranValue = document.getElementById('tran-value');
    const SanValue = document.getElementById('san-value');
    const G3MuaValue = document.getElementById('g3mua-value');
    const KL3MuaValue = document.getElementById('kl3mua-value');
    const G2MuaValue = document.getElementById('g2mua-value');
    const KL2MuaValue = document.getElementById('kl2mua-value');
    const G1MuaValue = document.getElementById('g1mua-value');
    const KL1MuaValue = document.getElementById('kl1mua-value');
    const GiaKLValue = document.getElementById('giakhoplenh-value');
    const KLKLValue = document.getElementById('klkhoplenh-value');
    const G1BanValue = document.getElementById('g1ban-value');
    const KL1BanValue = document.getElementById('kl1ban-value');
    const G2BanValue = document.getElementById('g2ban-value');
    const KL2BanValue = document.getElementById('kl2ban-value');
    const G3BanValue = document.getElementById('g3ban-value');
    const KL3BanValue = document.getElementById('kl3ban-value');
    const TotalKLValue = document.getElementById('tongkl-value');
    const OpenValue = document.getElementById('mocua-value');
    const TallestValue = document.getElementById('caonhat-value');
    const LowestValue = document.getElementById('thapnhat-value');
    const NNmuaValue = document.getElementById('nnmua-value');
    const NNbanValue = document.getElementById('nnban-value');
    const RoomValue = document.getElementById('roomconlai-value');

    const btnSubmit = document.querySelector('.btn')

    let output = '';
    let arrrayData = [];

    const renderPosts = (posts) => {
        console.log(arrrayData.length)
        for (var i = 0; i < posts.length; i++) {
            output += `
                            <tr class="MaCK" data-id=${posts[i].id}">
                                <td class="cccu fixedcol">
                                    ${posts[i].id}
                                </td>
                                <td class="g_r priceTC">${posts[i].price_TC}</td>
                                <td class="g_c priceTran">${posts[i].price_Tran}</td>
                                <td class="grf priceSan">${posts[i].price_San}</td>
                                <td class="b_r priceG3Buy" >${posts[i].g3_Buy}</td>
                                <td class="b_r priceKL3Buy" >${posts[i].kL3_Buy}</td>
                                <td class="b_r priceG2Buy" >${posts[i].g2_Buy}</td>
                                <td class="b_r priceKL2Buy" >${posts[i].kL2_Buy}</td>
                                <td class="b_r priceG1Buy" >${posts[i].g1_Buy}</td>
                                <td class="b_r priceKL1Buy" >${posts[i].kL1_Buy}</td>
                                <td class="b_c priceOrder">${posts[i].price_OrderExecution}</td>
                                <td class="b_c priceKLOrder" >${posts[i].kL_OrderExecution}</td>
                                <td class="b_r priceG1Sell" >${posts[i].g1_Sell}</td>
                                <td class="b_r priceKL1Sell" >${posts[i].kL1_Sell}</td>
                                <td class="b_r priceG2Sell" >${posts[i].g2_Sell}</td>
                                <td class="b_r priceKL2Sell" >${posts[i].kL2_Sell}</td>
                                <td class="b_r priceG3Sell" >${posts[i].g3_Sell}</td>
                                <td class="b_r priceKL3Sell" >${posts[i].kL3_Sell}</td>
                                <td class="g__ totalKL">${posts[i].totalKL}</td>
                                <td class="b_f openDoor" > ${ posts[i].openDoor}</td>
                                <td class="b_f tallest" > ${posts[i].tallest}</td >
                                <td class="b_u lowest" >${posts[i].lowest}</td>
                                <td class="g__ nnbuy">${posts[i].nnBuy}</td>
                                <td class="g__ nnsell">${posts[i].nnSell}</td>
                                <td class="g__ room">${posts[i].room_Left}</td>
                                <td><a class="btn btn-success" id="Update" onclick="edit(${i})">Edit</a></td>
                                <td><a class="btn btn-danger" id="Delete">Delete</a></td>
                                <td><input type="button" class="btn btn-primary" onclick="JoinGroup(${i})" id="joinGroup" value="Join Group Code" /></td>
                                <td><input type="button" class="btn btn-primary" onclick="ShowGroup()" value="Show Group"/></td>
                            </tr>`;
        }

        postlist.innerHTML = output;
    }


    const url = 'https://localhost:44318/api/Code';
    const urlCRUD = 'https://localhost:44318/api/CodeDetails';
    fetch(`${url}/GetAllCode`).then(res => res.json())
        .then(data => {
            arrrayData = data;
            //console.log(arrrayData)
            renderPosts(data)
        });
    console.log("calliing")

//async function asyncCall(){
  
    //const result = await addEvent();
    //console.log(result);
//}
   

    console.log("123")
    const edit = (index) => {
        //alert(index)
        //console.log(arrrayData)
        console.log(arrrayData[index])
        let PriceTC = arrrayData[index].price_TC;
        let PriceTran = arrrayData[index].price_Tran;
        let PriceSan = arrrayData[index].price_San;
        let G3Buy = arrrayData[index].g3_Buy;
        let KL3Buy = arrrayData[index].kL3_Buy;
        let G2Buy = arrrayData[index].g2_Buy;
        let KL2Buy = arrrayData[index].kL2_Buy;
        let G1Buy = arrrayData[index].g1_Buy;
        let KL1Buy = arrrayData[index].kL1_Buy;
        let PriceOrder = arrrayData[index].price_OrderExecution;
        let KLOrder = arrrayData[index].kL_OrderExecution;
        let G1Sell = arrrayData[index].g1_Sell;
        let KL1Sell = arrrayData[index].kL1_Sell;
        let G2Sell = arrrayData[index].g2_Sell;
        let KL2Sell = arrrayData[index].kL2_Sell;
        let G3Sell = arrrayData[index].g3_Sell;
        let KL3Sell = arrrayData[index].kL3_Sell;
        let TotalKL = arrrayData[index].totalKL;
        let OpenDoor = arrrayData[index].openDoor;
        let Tallest = arrrayData[index].tallest;
        let Lowest = arrrayData[index].lowest;
        let NNBuy = arrrayData[index].nnBuy;
        let NNSell = arrrayData[index].nnSell;
        let RoomLeft = arrrayData[index].room_Left;
        let Id = arrrayData[index].id;
        console.log(PriceTC, G3Buy, NNBuy, Tallest)

        IdValue.value = Id;
        TCValue.value = PriceTC;
        TranValue.value = PriceTran;
        SanValue.value = PriceSan;
        G3MuaValue.value = G3Buy;
        KL3MuaValue.value = KL3Buy;
        G2MuaValue.value = G2Buy;
        KL2MuaValue.value = KL2Buy;
        G1MuaValue.value = G1Buy;
        KL1MuaValue.value = KL1Buy;
        GiaKLValue.value = PriceOrder;
        KLKLValue.value = KLOrder;
        G1BanValue.value = G1Sell;
        KL1BanValue.value = KL1Sell;
        G2BanValue.value = G2Sell;
        KL2BanValue.value = KL2Sell;
        G3BanValue.value = G3Sell;
        KL3BanValue.value = KL3Sell;
        TotalKLValue.value = TotalKL;
        OpenValue.value = OpenDoor;
        TallestValue.value = Tallest;
        LowestValue.value = Lowest;
        NNmuaValue.value = NNBuy;
        NNbanValue.value = NNSell;
        RoomValue.value = RoomLeft;
    }
    btnSubmit.addEventListener('click', (e) => {
        e.preventDefault();

        var a = {
            id: parseInt(IdValue.value),
            price_TC: parseFloat(TCValue.value),
            price_San: parseFloat(SanValue.value),
            price_Tran: parseFloat(TranValue.value),
            g1_Buy: parseFloat(G1MuaValue.value),
            kL1_Buy: parseFloat(KL1MuaValue.value),
            g2_Buy: parseFloat(G2MuaValue.value),
            kL2_Buy: parseFloat(KL2MuaValue.value),
            g3_Buy: parseFloat(G3MuaValue.value),
            kL3_Buy: parseFloat(KL3MuaValue.value),
            price_OrderExecution: parseFloat(GiaKLValue.value),
            kL_OrderExecution: parseFloat(KLKLValue.value),
            g1_Sell: parseFloat(G1BanValue.value),
            kL1_Sell: parseFloat(KL1BanValue.value),
            g2_Sell: parseFloat(G2BanValue.value),
            kL2_Sell: parseFloat(KL2BanValue.value),
            g3_Sell: parseFloat(G3BanValue.value),
            kL3_Sell: parseFloat(KL3BanValue.value),
            totalKL: parseFloat(TotalKLValue.value),
            openDoor: parseFloat(OpenValue.value),
            tallest: parseFloat(TallestValue.value),
            lowest: parseFloat(LowestValue.value),
            nnBuy: parseFloat(NNmuaValue.value),
            nnSell: parseFloat(NNbanValue.value),
            room_Left: parseFloat(RoomValue.value)
        }
        console.log(a);
        fetch(`${urlCRUD}/Update`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(a)
        })
            .then(res => res.json())
            .catch(error => {
                console.log(error);
            })
            .then(() => location.reload())
    })


var connection = new signalR.HubConnectionBuilder().withUrl("/groupHub").build();

connection.start().catch(function (err) {
    return console.error(err.toString());
});



connection.on("ReceveiMessage", function (message) {
    console.log(message)
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    div.innerHTML = "User says : " + msg + "<hr/>";
    document.getElementById("messages").appendChild(div);

});

connection.on('UserConnected', function (connectionId) {
    var groupElement = document.getElementById("group");
    var option = document.createElement("option");
    option.text = connectionId;
    option.value = connectionId;
    groupElement.add(option);
});
connection.on('UserDisconnected', function (connectionId) {
    var groupElement = document.getElementById("group");
    for (var i = 0; i < groupElement.length; i++) {
        if (groupElement.option[i].value === connectionId) {
            groupElement.remove(i);
        }
    }
})

//connection.Reconnecting += error => {
//    Debug.Assert(connection.State == HubConnectionState.Reconnecting);

//    // Notify users the connection was lost and the client is reconnecting.
//    // Start queuing or dropping messages.

//    return Task.CompletedTask;
//};

//function addEvent() {
   
//}

    //document.getElementById("joinGroup").addEventListener("click", function (event) {
    //connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
    //    return console.error(err.toString());
    //});
    //console.log('join group')
    //event.preventDefault();
    //})

function ShowGroup() {
    var priceList = {
        PriceTC: document.getElementsByClassName('priceTC').textContent,
         PriceTran : arrrayData[index].price_Tran,
         PriceSan : arrrayData[index].price_San,
         G3Buy : arrrayData[index].g3_Buy,
         KL3Buy : arrrayData[index].kL3_Buy,
         G2Buy : arrrayData[index].g2_Buy,
         KL2Buy : arrrayData[index].kL2_Buy,
         G1Buy : arrrayData[index].g1_Buy,
         KL1Buy : arrrayData[index].kL1_Buy,
         PriceOrder : arrrayData[index].price_OrderExecution,
         KLOrder : arrrayData[index].kL_OrderExecution,
         G1Sell : arrrayData[index].g1_Sell,
         KL1Sell : arrrayData[index].kL1_Sell,
         G2Sell : arrrayData[index].g2_Sell,
         KL2Sell : arrrayData[index].kL2_Sell,
         G3Sell : arrrayData[index].g3_Sell,
         KL3Sell : arrrayData[index].kL3_Sell,
         TotalKL : arrrayData[index].totalKL,
         OpenDoor : arrrayData[index].openDoor,
         Tallest : arrrayData[index].tallest,
         Lowest : arrrayData[index].lowest,
         NNBuy : arrrayData[index].nnBuy,
         NNSell : arrrayData[index].nnSell,
         RoomLeft : arrrayData[index].room_Left,
         Id : arrrayData[index].id
    }
    connection.invoke("SendMessageToGroup", "PrivateGroup", JSON.stringify(priceList)).catch(function (err) {
        return console.error(err.toString());
    });  
}

connection.on("ReceveiMessage", function ( priceList) {
    var msg = priceList.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg =   "Nong says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});
       
function JoinGroup() {
    connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
        return console.error(err.toString());
    });
    console.log('join group')
    event.preventDefault();
}


    
//asyncCall();


