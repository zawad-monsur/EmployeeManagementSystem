import 'react';
import { CssBaseline, Container } from '@mui/material';
import EmployeeList from './components/EmployeeList';

function App() {
    return (
        <div className="App">
            <CssBaseline />
            <Container maxWidth="lg" sx={{ py: 4 }}>
                <EmployeeList />
            </Container>
        </div>
    );
}

export default App;