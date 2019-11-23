import React, { useEffect, useState } from "react";
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";

export const Audit: React.FC = () => {
  const [hubConnection, setHubConnection] = useState<HubConnection>();
  const [messages, setMessages] = useState<string[]>([]);
  // Set the Hub Connection on mount.
  useEffect(() => {
    // Set the initial SignalR Hub Connection.
    const createHubConnection = async () => {
      // Build new Hub Connection, url is currently hard coded.
      const hubConnect = new HubConnectionBuilder()
        .withUrl("https://localhost:5001/hubs/audit")
        .build();
      try {
        await hubConnect.start();
        console.log("Connection successful!");
        hubConnect.on("SendAudit", (receivedMessage: string) => {
          setMessages(m => [...m, receivedMessage]);
        });
      } catch (err) {
        alert(err);
      }
      setHubConnection(hubConnect);
    };

    createHubConnection();
  }, []);

  return (
    <>
      <h3>Evren</h3>
      {JSON.stringify(messages)}
      <ul>
        {messages.map(m => (
          <li>{m}</li>
        ))}
      </ul>
    </>
  );
};
