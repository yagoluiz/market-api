# /bin/bash

kubectl apply -f namespaces/market-namespace.yaml

kubectl apply -f deployments/market-database-deployment.yaml
kubectl apply -f deployments/market-api-deployment.yaml

kubectl apply -f services/market-database-service.yaml
kubectl apply -f services/market-api-service.yaml
