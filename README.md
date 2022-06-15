# newerthings

Charts folder contains the template for the Helm Chart deployment.

`helm upgrade --install . my-test-release`

Simplest way to install Apache Kafka:

``` 
helm repo add bitnami https://charts.bitnami.com/bitnami
helm install my-release bitnami/kafka 
```

After installing test the Apache Kafka using,
```
To create a pod that you can use as a Kafka client run the following commands:

    kubectl run my-release-kafka-client --restart='Never' --image docker.io/bitnami/kafka:3.2.0-debian-11-r3 --namespace default --command -- sleep infinity
    kubectl exec --tty -i my-release-kafka-client --namespace default -- bash

    PRODUCER:
        kafka-console-producer.sh --broker-list my-release-kafka-0.my-release-kafka-headless.default.svc.cluster.local:9092 --topic test

    CONSUMER:
        kafka-console-consumer.sh --bootstrap-server my-release-kafka.default.svc.cluster.local:9092 --topic test --from-beginning
```

[Follow this example for more info.](https://andrewlock.net/deploying-asp-net-core-applications-to-kubernetes-part-4-creating-a-helm-chart-for-an-aspnetcore-app/)
