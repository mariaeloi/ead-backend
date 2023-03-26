FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /ead-backend

COPY . .

EXPOSE 5000
EXPOSE 5001

RUN chmod +x dotnetef.sh

ENTRYPOINT [ "./dotnetef.sh" ]
