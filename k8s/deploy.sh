# /bin/bash

PATH_DEFAULT=k8s

kubectl apply -f $PATH_DEFAULT/namespaces/market-namespace.yaml

kubectl apply -f $PATH_DEFAULT/deployments/market-database-deployment.yaml
kubectl apply -f $PATH_DEFAULT/deployments/market-api-deployment.yaml

kubectl apply -f $PATH_DEFAULT/services/market-database-service.yaml
kubectl apply -f $PATH_DEFAULT/services/market-api-service.yaml
