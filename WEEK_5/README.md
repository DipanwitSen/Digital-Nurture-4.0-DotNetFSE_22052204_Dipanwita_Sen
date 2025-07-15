# Kafka Chat App using C# (.NET) on Windows

This project demonstrates a **real-time chat system** using **Apache Kafka** as the message broker and **C# (.NET)** as the application layer. Messages are published by one user (producer) and received by another (consumer) in real-time using Kafka topics.

---
## 📌 What is Apache Kafka?

**Apache Kafka** is an open-source distributed **event streaming platform** that:
- Handles high-throughput real-time data feeds
- Works on a **publish-subscribe** model
- Is fault-tolerant, scalable, and durable

Kafka is widely used for:
- Real-time analytics
- Log aggregation
- Messaging systems
- Event sourcing

---

## 🧠 Project Overview

- **Producer App**: A C# console app that sends messages to Kafka (chat messages).
- **Consumer App**: A C# console app that listens to messages from Kafka and displays them.
- **Kafka**: Acts as the messaging middleware.
- **Zookeeper**: Required by Kafka for managing broker coordination.

---

## 🛠 Tech Stack

- Apache Kafka 3.6.1 (Scala 2.13)
- Java 21 (LTS)
- .NET 7.0+ (Visual Studio 2022)
- Confluent.Kafka NuGet library

---

## 🔧 Kafka & Zookeeper Setup (Windows)
- 1 Zookeeeper
- cd C:\kafka\bin\windows
zookeeper-server-start.bat ..\..\config\zookeeper.properties
-2 Kafta
-cd C:\kafka\bin\windows
kafka-server-start.bat ..\..\config\server.properties
-3 Create Kafta Topic
-cd C:\kafka\bin\windows
kafka-topics.bat --create --topic chat-topic --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1

### 1. ✅ Download Kafka

- Download Kafka from: https://kafka.apache.org/downloads
- Recommended: `kafka_2.13-3.6.1.tgz`
- Extract it to `C:\kafka`


