Build/execution instructions are given in the root directories of every folder where the relevant projects reside.

**In this directory**, the first three hands-on exercises have been dealt with. To get up and going, start the mssql docker container:
```sh
cd .scripts
docker compose up --build -d
```

To set up all the databases used here, you can source the `.scripts/init.sql` file.
