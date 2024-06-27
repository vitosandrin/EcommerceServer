it may give a certificate/tls error when running services in Docker. 
to solve:
dotnet dev-certs https --clean
dotnet dev-certs https --trust
restart VS