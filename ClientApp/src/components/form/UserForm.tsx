import { Box, Button, TextField, Typography } from "@mui/material";

interface IUserFormProps {
    onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
    onChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
    type: 'signup' | 'login',
    error: boolean
}

export default function UserForm({ error, onSubmit, onChange, type }: IUserFormProps) {
    return (
        <form onSubmit={onSubmit}>
            <Box sx={{ display: 'flex', flexDirection: 'column' }}>
                <Typography>{type === 'signup' ? 'Sign Up' : 'Log In'}</Typography>
                <TextField error={error} required name="username" onChange={onChange} sx={{ my: 1 }} label="Username" />
                <TextField error={error} required type="password" name="password" onChange={onChange} sx={{ my: 1 }} label="Password" helperText={error && "Invalid credentials"} />
                <Button type="submit">{type === 'signup' ? 'Submit' : 'Login'}</Button>
            </Box>
        </form>
    )
}