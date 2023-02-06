"use strict";

//Build the connection and set it on the adress where the connection will be opened
var connection = new SignalR.HubConnectionBuilder().withUrl("/chathub").build();

documetn.getElementById("sendButton").disabled = true;

//Create event handler for SignalR,it's not event for JS
connection.on("ReceiveMessage", function (user1, user2, sender, receiver, message) {
    if (user1==sender) {
        var li = document.createElement("li");
        document.getElementById("user1Sender").appendChild("li");
        li.textContent = `${message}`;
        li.textContent = `${Date.now}`;

        var p = document.getElementById("contentUser1");
        p.textContent = `${message}`;
        var p1 = document.getElementById("createdOnUser1");
        p1.textContent = `${Date.now}`;
    }
    else{
        var li = document.createElement("li");
        document.getElementById("user2Sender").appendChild("li");
        li.textContent = `${message}`;
        li.textContent = `${Date.now}`;
    }
    
});

//Enables the button when the connection is build
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

//Event handler
document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    event.stopPropagation();
    //var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",message).catch(function (err) {
        return console.error(err.toString());
    });
});