import React, { useState, useEffect } from 'react';
import {
    Table, TableBody, TableCell, TableContainer,
    TableHead, TableRow, Paper, Typography,
    IconButton, TablePagination
} from '@mui/material';
import { Edit, Delete } from '@mui/icons-material';
import { getEmployees, getDepartments } from '../services/employeeService';
import SearchBar from './SearchBar';

const EmployeeList = () => {
    const [employees, setEmployees] = useState([]);
    const [departments, setDepartments] = useState([]);
    const [page, setPage] = useState(0);
    const [totalCount, setTotalCount] = useState(0);
    const [filters, setFilters] = useState({
        search: '',
        department: '',
        minScore: ''
    });

    const loadData = async () => {
        const [depts, emps] = await Promise.all([
            getDepartments(),
            getEmployees(page + 1, filters.search, filters.department, filters.minScore)
        ]);

        setDepartments(depts);
        setEmployees(emps.items);
        setTotalCount(emps.totalCount);
    };

    useEffect(() => {
        loadData();
    }, [page, filters]);

    const handlePageChange = (event, newPage) => {
        setPage(newPage);
    };

    return (
        <Paper sx={{ p: 3 }}>
            <Typography variant="h5" gutterBottom>
                Employee Management
            </Typography>

            <SearchBar
                onSearch={setFilters}
                departments={departments}
            />

            <TableContainer>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Name</TableCell>
                            <TableCell>Email</TableCell>
                            <TableCell>Department</TableCell>
                            <TableCell>Position</TableCell>
                            <TableCell>Score</TableCell>
                            <TableCell>Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {employees.map((employee) => (
                            <TableRow key={employee.employeeID}>
                                <TableCell>{employee.name}</TableCell>
                                <TableCell>{employee.email}</TableCell>
                                <TableCell>
                                    {departments.find(d => d.departmentID === employee.departmentID)?.departmentName}
                                </TableCell>
                                <TableCell>{employee.position}</TableCell>
                                <TableCell>
                                    {employee.performanceReviews?.[0]?.reviewScore || '-'}
                                </TableCell>
                                <TableCell>
                                    <IconButton color="primary">
                                        <Edit />
                                    </IconButton>
                                    <IconButton color="error">
                                        <Delete />
                                    </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            <TablePagination
                component="div"
                count={totalCount}
                page={page}
                onPageChange={handlePageChange}
                rowsPerPage={10}
                rowsPerPageOptions={[10]}
            />

            <Typography variant="h6" sx={{ mt: 4, mb: 2 }}>
                Department Performance Averages
            </Typography>
            <PerformanceChart />
        </Paper>
    );
};

export default EmployeeList;