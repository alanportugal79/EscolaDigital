import {environment} from '../../environments/environment';

export const routes = {
    session: {
        getCurrentUser: environment.apiSessionPath + '/current-user',
        getMenu: environment.apiSessionPath + '/menu',
        getCurrentUserPhotoThumbnail: environment.sessionFilesPath + '/ProfilePhoto',
    }
}