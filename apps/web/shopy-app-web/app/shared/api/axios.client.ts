import axios from "axios";

export const API_URL = `http://localhost:5228/api`;

const apiClient = axios.create({
	withCredentials: true,
	baseURL: API_URL,
});

apiClient.interceptors.request.use((config) => {
	config.headers.Authorization = `Bearer ${localStorage.getItem("access_token")}`;
	return config;
});

export default apiClient;
