import axios, { AxiosResponse, AxiosInstance } from 'axios';

const responseBody = (response: AxiosResponse) => response.data;

const DomainEndPoint = process.env.BaseURL || 'http://localhost:5003/api/';

class BaseServices {
  protected request: AxiosInstance;

  constructor(baseURL: string = DomainEndPoint, secretKey = '') {
    this.request = axios.create({ baseURL, withCredentials: false });
    this.request.defaults.headers['api-master-key'] = '7c11adea-3a34-4394-bab5-3fc8a0a02999';
    if (secretKey) this.request.defaults.headers['api-secret-key'] = secretKey;
    this.configRequest();
  }

  private configRequest() {
    this.request.interceptors.request.use(
      (config) => {
        return config;
      },
      (error) => {
        return Promise.reject(error);
      }
    );
  }

  protected get(url: string) {
    return this.request.get(url).then(responseBody);
  }

  protected postWithConfigHeader(url: string, data: any, config: any) {
    return this.request.post(url, data, config).then(responseBody);
  }

  protected post(url: string, body: {}) {
    return this.request.post(url, body).then(responseBody);
  }

  protected put(url: string, body: {}) {
    return this.request.put(url, body).then(responseBody);
  }

  protected delete(url: string) {
    return this.request.delete(url).then(responseBody);
  }
}

export default BaseServices;
