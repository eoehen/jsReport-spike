# jsReport spike

## Questions

### Infra

- [ ] Test jsReport studio (pro / contra)
- [ ] Rendering server container with request
- [ ] Template synchronisation from minio. (https://jsreport.net/learn/template-stores)
- [ ] Upload result to minio / s3 storage.
- [ ] Parallel running Problem with multiple local instances (f.e. parallel tests) not working.
- [ ] Render eninges? (https://jsreport.net/learn/templating-engines)
- [ ] Possible to combine with other pdf files.
- [ ] Debugging

### Templating

- [ ] Splitted templates for reusing (footer, header, reusing elements)
- [ ] Shared style file (f.e. css)
- [ ] Override custom styles for a template

### Rendering

- [x] List of data (foreach)
- [x] condition in templates (if)
- [x] Include dynamic images (base64)
- [x] Fonts (pdf-integration)
- [x] Prepare splitted template and data. Replace dynamic data in template.
- [x] encoding (Ä,Ü,Ö) --> Template must have the correct encoding.
- [x] render dynamic html elements from data. --> use dribble brackets `{{{dynHtml}}}`
- [ ] Add Page break (https://jsreport.net/blog/pdf-report-paging-and-page-breaks)
- [ ] Page number (f.e. in footer template)
- [ ] Page Format f.e. A4 or A5
- [ ] Localization
- [ ] Html rendering (UseCase: E-Mail Templating)
- [ ] Support of dynamic js scripts f.e. charts (js)

## Setup Docker

**Docker Desktop**

Required `https://docs.docker.com/desktop/`

**Docker Hub**

https://hub.docker.com/r/jsreport/jsreport

**docker-compose**

Startup jsReport host docker container.

> Published on Port : `15488`

`.\docker\docker-compose.yml`

```
docker-compose up -d
```

## jsReport references

**Product**

https://jsreport.net

### Engines

**handlebars**

https://handlebarsjs.com/

## Sync Templates

https://jsreport.net/learn/fs-store?version=2.11.0#cloud-storage
