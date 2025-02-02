import api from './api';

export const getEmployees = async (page = 1, search = '', department = '', minScore = '') => {
  const params = new URLSearchParams({
    page,
    pageSize: 10,
    name: search,
    department,
    minScore
  });
  
  const response = await api.get(`/employees?${params}`);
  return response.data;
};

export const getDepartments = async () => {
  const response = await api.get('/departments');
  return response.data;
};

export const getDepartmentAverages = async () => {
  const response = await api.get('/departments/average-scores');
  return response.data;
};