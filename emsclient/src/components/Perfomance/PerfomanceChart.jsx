import { useEffect, useState } from 'react';
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import { getDepartmentAverages } from '../services/employeeService';

const PerformanceChart = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const result = await getDepartmentAverages();
      setData(result);
    };
    fetchData();
  }, []);

  return (
    <div style={{ height: '400px', marginTop: '2rem' }}>
      <ResponsiveContainer width="100%" height="100%">
        <BarChart data={data}>
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="departmentName" />
          <YAxis domain={[0, 10]} />
          <Tooltip />
          <Bar dataKey="averageScore" fill="#8884d8" />
        </BarChart>
      </ResponsiveContainer>
    </div>
  );
};

export default PerformanceChart;