export class ApiBase {
    protected static get = async (url: string) => {
        const response = await fetch(url, ApiBase.getFetchOptions('GET'));

        return ApiBase.processResponse(response);
    };

    protected static post = async (url: string, body?: unknown, serializeBody = true, contentType = 'application/json') => {
        return ApiBase.request('POST', url, body, serializeBody, contentType);
    };

    protected static put = async (url: string, body?: unknown, serializeBody = true, contentType = 'application/json') => {
        return ApiBase.request('PUT', url, body, serializeBody, contentType);
    };

    protected static delete = async (url: string, body?: unknown, serializeBody = true, contentType = 'application/json') => {
        return ApiBase.request('DELETE', url, body, serializeBody, contentType);
    };

    protected static request = async (method: string, url: string, body?: unknown, serializeBody = true, contentType = 'application/json') => {
        const response = await fetch(url, ApiBase.getFetchOptions(method, contentType, body != undefined && serializeBody ? JSON.stringify(body) : body as FormData | string | null));

        return ApiBase.processResponse(response);
    };

    private static getFetchOptions = (method: string, contentType = 'application/json', body?: FormData | string | null): RequestInit => {
        const headers = new Headers();

        headers.append('Accept', 'application/json');
        //TODO: Add Authorization
        //headers.append('Authorization', '');

        if (contentType) {
            headers.append('Content-Type', contentType);
        }

        return { body, credentials: 'same-origin', headers, method };
    };

    private static processResponse = async (response: Response) => {
        return response.json();
    };
}
