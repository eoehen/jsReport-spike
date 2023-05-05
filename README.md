# jsReport spike

## Questions

- Prepare splitted template and data. Replace dynamic data in template.
- Splitted templates for reusing (Footer, Header, reusing Elements)
- List of data (foreach)
- Template synchronisation from minio. (https://jsreport.net/learn/template-stores)
- Upload output to minio / s3 storage.
- Include dynamic images or charts (js)
- Localization
- Fonts (pdf-interation)

## Setup Docker

**Docker Desktop**

Required `https://docs.docker.com/desktop/`

**Docker Hub**

https://hub.docker.com/r/jsreport/jsreport

**docker-compose**

Startup jsReport host docker container.

`.\docker\docker-compose.yml`

```
docker-compose up -d
```

## jsReport references

**Product**

https://jsreport.net

## Sync Templates

https://jsreport.net/learn/fs-store?version=2.11.0#cloud-storage
