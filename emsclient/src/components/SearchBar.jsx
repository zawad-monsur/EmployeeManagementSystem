import React, { useState } from 'react';
import { TextField, MenuItem, Grid, Button } from '@mui/material';

const SearchBar = ({ onSearch, departments }) => {
    const [searchTerm, setSearchTerm] = useState('');
    const [selectedDept, setSelectedDept] = useState('');
    const [minScore, setMinScore] = useState('');

    const handleSearch = () => {
        onSearch({
            search: searchTerm,
            department: selectedDept,
            minScore: minScore
        });
    };

    return (
        <Grid container spacing={2} alignItems="center" sx={{ mb: 3 }}>
            <Grid item xs={12} sm={4}>
                <TextField
                    fullWidth
                    label="Search by Name"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
            </Grid>
            <Grid item xs={12} sm={3}>
                <TextField
                    select
                    fullWidth
                    label="Department"
                    value={selectedDept}
                    onChange={(e) => setSelectedDept(e.target.value)}
                >
                    <MenuItem value="">All Departments</MenuItem>
                    {departments.map((dept) => (
                        <MenuItem key={dept.departmentID} value={dept.departmentID}>
                            {dept.departmentName}
                        </MenuItem>
                    ))}
                </TextField>
            </Grid>
            <Grid item xs={12} sm={3}>
                <TextField
                    select
                    fullWidth
                    label="Minimum Score"
                    value={minScore}
                    onChange={(e) => setMinScore(e.target.value)}
                >
                    <MenuItem value="">Any Score</MenuItem>
                    {[6, 7, 8, 9].map((score) => (
                        <MenuItem key={score} value={score}>{score}+</MenuItem>
                    ))}
                </TextField>
            </Grid>
            <Grid item xs={12} sm={2}>
                <Button
                    fullWidth
                    variant="contained"
                    onClick={handleSearch}
                >
                    Search
                </Button>
            </Grid>
        </Grid>
    );
};

export default SearchBar;