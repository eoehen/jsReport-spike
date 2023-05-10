# jsReport spike

## Questions

### Infra

- [x] Container availability check - http://jsreport-host/api/ping (https://jsreport.net/learn/api#ping)
- [x] Secure API behind authentication (https://jsreport.net/learn/authentication)
- [x] Rendering server container with request
- [ ] Template synchronisation from minio. (https://jsreport.net/learn/template-stores) - at the moment only to filesystem
- [ ] Upload result to minio / s3 storage. - at the moment only to filesystem
- [ ] Parallel running Problem with multiple local instances (f.e. parallel tests) not working.
- [ ] Render eninges? (https://jsreport.net/learn/templating-engines)
- [ ] Possible to combine with other pdf files.
- [ ] Debugging
- [ ] Test jsReport studio (pro / contra)

### Rendering / Templateing

- [x] List of data (foreach)
- [x] condition in templates (if)
- [x] Include dynamic images (base64)
- [x] Fonts (pdf-integration)
- [x] Prepare splitted template and data. Replace dynamic data in template.
- [x] encoding (Ä,Ü,Ö) --> Template must have the correct encoding.
- [x] render dynamic html elements from data. --> use dribble brackets `{{{dynHtml}}}`
- [x] Add Page break (https://jsreport.net/blog/pdf-report-paging-and-page-breaks)
- [x] Shared style file (f.e. css)
- [x] Override custom styles for a template
- [x] Support for Header and Footer with page number
- [ ] Page Format f.e. A4, A5 or custom size
- [ ] Localization
- [ ] Formating of datetime or numbers.

### Low Prio / nice to have

- [x] Html rendering (UseCase: E-Mail Templating) --> The `CopyToAsync` with content not working.
- [x] Render to image (UseCase: Tumbnails)
- [ ] Splitted templates for reusing https://handlebarsjs.com/guide/partials.html#basic-partials, https://jsreport.net/learn/child-templates?version=2.11.0
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
