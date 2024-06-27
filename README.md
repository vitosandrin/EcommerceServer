it may give a certificate/tls error try connect with https when running services in Docker. 
to solve:

dotnet dev-certs https --clean

dotnet dev-certs https --trust

restart VS
