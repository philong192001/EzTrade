var connection = new signalR.HubConnectionBuilder().withUrl("/signalrHub").build();
console.log("SignalR Connected.");
connection.start().catch(function (err) {
    return console.error(err.toString());
});

function showInfo() {
    //function json(url) {
    //    return fetch(url).then(res => res.json());
    //}

    //let apiKey = 'fa5711b26f59dc32b03ce81dc3fc6e660ef3696ce251246ea2e4a270';
    //json(`https://api.ipdata.co?api-key=${apiKey}`).then(data => {
    //    console.log(data.ip);
    //    console.log(data.city);
    //    console.log(data.country_code);
    //    // so many more properties
    //});
 
    function text(url) {
        return fetch(url).then(res => res.text());
    }

    text('https://www.cloudflare.com/cdn-cgi/trace').then(data => {
        let ipRegex = /[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}/
        let ip = data.match(ipRegex)[0];     
        //console.log(ip);
        var ipUser = document.createElement("h5");
        ipUser.innerHTML = "User used IP : " + ip + "<hr/>";
        document.getElementById('message').appendChild(ipUser);
    });

    var broswer = navigator.userAgent;
    var h1 = document.createElement("h5");
    h1.innerHTML = "User used : " + broswer + "<hr/>";
    document.getElementById('message').appendChild(h1);
    //console.log(navigator.userAgent)
}