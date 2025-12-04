import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse, AxiosError } from 'axios';

/**
 * Configuration for the API client
 */
export interface ApiClientConfig {
  baseURL: string;
  token?: string;
  timeout?: number;
}

/**
 * Base API client with authentication and error handling
 */
export class ApiClient {
  private axiosInstance: AxiosInstance;
  private token?: string;

  constructor(config: ApiClientConfig) {
    this.token = config.token;
    this.axiosInstance = axios.create({
      baseURL: config.baseURL,
      timeout: config.timeout || 30000,
      headers: {
        'Content-Type': 'application/json',
      },
    });

    // Add request interceptor for authentication
    this.axiosInstance.interceptors.request.use(
      (config) => {
        if (this.token) {
          config.headers.Authorization = `Bearer ${this.token}`;
        }
        return config;
      },
      (error) => {
        return Promise.reject(error);
      }
    );

    // Add response interceptor for error handling
    this.axiosInstance.interceptors.response.use(
      (response) => response,
      (error: AxiosError) => {
        // Handle common errors
        if (error.response) {
          // Server responded with error status
          const status = error.response.status;
          const message = error.response.data || error.message;
          
          throw new ApiError(
            `API Error: ${status}`,
            status,
            message,
            error.response.headers
          );
        } else if (error.request) {
          // Request was made but no response received
          throw new ApiError(
            'Network Error: No response received',
            0,
            error.message
          );
        } else {
          // Something else happened
          throw new ApiError(
            'Request Error',
            0,
            error.message
          );
        }
      }
    );
  }

  /**
   * Set or update the authentication token
   */
  setToken(token: string): void {
    this.token = token;
  }

  /**
   * Clear the authentication token
   */
  clearToken(): void {
    this.token = undefined;
  }

  /**
   * Make a GET request
   */
  async get<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    const response = await this.axiosInstance.get<T>(url, config);
    return response.data;
  }

  /**
   * Make a POST request
   */
  async post<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    const response = await this.axiosInstance.post<T>(url, data, config);
    return response.data;
  }

  /**
   * Make a PUT request
   */
  async put<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    const response = await this.axiosInstance.put<T>(url, data, config);
    return response.data;
  }

  /**
   * Make a DELETE request
   */
  async delete<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    const response = await this.axiosInstance.delete<T>(url, config);
    return response.data;
  }

  /**
   * Get the underlying axios instance for advanced usage
   */
  getAxiosInstance(): AxiosInstance {
    return this.axiosInstance;
  }
}

/**
 * Custom API error class
 */
export class ApiError extends Error {
  constructor(
    message: string,
    public status: number,
    public data?: any,
    public headers?: any
  ) {
    super(message);
    this.name = 'ApiError';
    Object.setPrototypeOf(this, ApiError.prototype);
  }
}
