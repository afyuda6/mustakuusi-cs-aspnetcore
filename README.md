# mustakuusi-cs-aspnetcore
for learning purposes

## Start Server
```bash
dotnet run --urls="http://localhost:3002"
```

## Get Games
```text
curl -X 'GET' \
  'http://localhost:3002/games' \
  -H 'accept: */*'
```

## Get Characters
```text
curl -X 'GET' \
  'http://localhost:3002/characters' \
  -H 'accept: */*'
```