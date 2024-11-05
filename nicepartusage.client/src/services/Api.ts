import { ApiBase } from './ApiBase';

const baseUrl = (import.meta.env.VITE_API_BASE_URL) ?? '';

export class Api extends ApiBase {
    public static readonly getNpuCreations = (element = '') => ApiBase.get(`${baseUrl}/npuCreation?element=${element}`);

    public static readonly getElements = () => ApiBase.get(`${baseUrl}/element`);
};
