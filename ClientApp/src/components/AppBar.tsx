import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from 'utils/hooks';
import { logout } from 'data/authSlice';


export default function ButtonAppBar() {
  const navigate = useNavigate()
  const authenticated = useAppSelector(state => state.auth.authenticated)
  const dispatch = useAppDispatch()

  const handleLogout = () => {
    dispatch(logout())

  }

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>

          <Typography onClick={() => navigate('/')} variant="h6" component="div"
            sx={{
              flexGrow: 1,
              cursor: 'pointer',
            }}
          >
            Foodb
          </Typography>
          {authenticated ? <Button color="inherit" onClick={handleLogout}>Logout</Button>
            : (
            <>
            <Button color="inherit" onClick={() => navigate('/signup')}>Sign Up</Button>
            <Button color="inherit" onClick={() => navigate('/login')}>Login</Button>
            </>
            )}
        </Toolbar>
      </AppBar>
    </Box>
  );
}