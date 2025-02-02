// services/api.js
import axios from 'axios';

const api = axios.create({
    baseURL: process.env.NODE_ENV === 'development'
        ? 'https://localhost:5001'  # Match your .NET Core port
        : '/api',
});

export default api;

// services/employeeService.js
import api from './api';

export const getEmployees = async (page = 1, searchTerm = '') => {
    const response = await api.get(`/employees?page=${page}&pageSize=10&search=${searchTerm}`);
    return response.data;
};

export const createEmployee = async (employeeData) => {
    return await api.post('/employees', employeeData);
};

// Similar services for update/delete