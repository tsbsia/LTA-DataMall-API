# [LTA DataMall API](https://lta-datamall-api.azurewebsites.net)

An ASP.NET Web API for querying transport-related datasets from [Singapore LTA DataMall](https://datamall.lta.gov.sg/content/datamall/en/dynamic-data.html).

[![image](https://github.com/tsbsia/LTA-DataMall-API/assets/7907945/162c295e-144b-49a7-b982-29e04cc52570)](https://lta-datamall-api.azurewebsites.net)

---

## Join my [Discord Server](https://discord.gg/GkhjfYth) and <img alt="Telegram" src="https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Telegram_logo.svg/512px-Telegram_logo.svg.png?20220101141644" decoding="async" width="24" height="24">  [Telegram Channel](https://t.me/s/ltadatamallapi) 

[![Discord](https://discord.com/api/guilds/1164014124871733309/widget.png?style=banner3)](https://discord.gg/GkhjfYth)


---


## 1. Account Key

   You can request an Account Key from [LTA DATAMALL](https://datamall.lta.gov.sg/content/datamall/en/request-for-api.html).


## 2. Forking or Cloning Code
   ```
   git clone "https://github.com/tsbsia/LTA-DataMall-API.git"
   ```

## 3. Setting Up Account Key
#### Change to project directory
   ```
   cd .\LTA-DataMall-API\src\
   ```
   
#### Enable secret storage
   ```
   dotnet user-secrets init
   ```
#### Set account key secret 
   ```   
   dotnet user-secrets set "LtaDataService:AccountKey" "[YOUR-ACCOUNT-KEY]"
   ```
## 4. Build and Run

#### Restore 
   ```
   dotnet restore
   ```
#### Build
   ```
   dotnet build
   ```
#### Run 
   ```
   dotnet run --launch-profile "Web API"
   ```
#### Browse 

Open URL [https://localhost:7153/index.html](https://localhost:7153/index.html) in web browser.



---

