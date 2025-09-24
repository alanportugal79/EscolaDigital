export const environment = {
  apiSessionPath: `${location.protocol}//${location.hostname}:5093/api/Session`,
  sessionFilesPath: `${location.protocol}//${location.hostname}:5093/SessionFiles`,
  authority: `${location.protocol}//${location.hostname}:8080/realms/EscolaDigital`,
  clientId: 'web',
  resourceServerId: 'session_api',
};