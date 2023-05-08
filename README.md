# jsReport spike

## Questions

### Infra

- [ ] Test jsReport studio (pro / contra)
- [ ] Rendering server container with request
- [ ] Template synchronisation from minio. (https://jsreport.net/learn/template-stores)
- [ ] Upload result to minio / s3 storage.
- [ ] Parallel running Problem with multiple local instances (f.e. parallel tests) not working.

### Templating

- [ ] Splitted templates for reusing (footer, header, reusing elements)
- [ ] Shared style file (f.e. css), override shared style in template

### Rendering

- [ ] Prepare splitted template and data. Replace dynamic data in template.
- [x] List of data (foreach)
- [ ] condition in templates (if)
- [x] Include dynamic images (base64)
- [ ] Support of dynamic js scripts f.e. charts (js)
- [ ] Localization
- [ ] Fonts (pdf-integration)
- [ ] encoding (Ä,Ü,Ö)
- [ ] render dynamic html elements from data.

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
