# Kafka Implementation on .NET Core Web API for Order Management

## Overview

This repository showcases a robust implementation of Apache Kafka in a .NET Core Web API designed for Order Management. The objective is to demonstrate the seamless integration of Kafka for communication within a distributed system. The system consists of an Order Request API responsible for producing orders to a Kafka topic, and a background service adept at consuming these orders for subsequent processing.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Apache Kafka](https://kafka.apache.org/downloads)
- [Docker](https://www.docker.com/get-started) (optional, for running Kafka locally)

## Getting Started

1. **Clone the repository:**

   ```bash
   git clone https://github.com/warrickrandi/dotnet-kafka-implementation.git
   cd kafka-dotnet-order-management

2. **Set up Kafka**
   - To Install Kafka Locally using Docker [Docker Compose File](https://github.com/warrickrandi/kafka-docker.git)
     
3.  **Run the API**

4.  **Send Order Request**
   When send the order Request, Order Request will produce to Kafka Topic

## Background Service 

The 'BackgroundWorkerService.cs' is a background service that consumes orders from the Kafka topic.
