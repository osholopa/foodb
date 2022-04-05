import React, { useState } from "react";
import { Box } from "@mui/material";
import DefaultLayout from "layouts/DefaultLayout";
import UserForm from "components/form/UserForm";
import { useNavigate } from "react-router-dom";
import { useSignUpMutation } from "data/foodbApi";


export default function SignUp() {
    const [values, setValues] = useState({
        username: "",
        password: "",
    });
    const [error, setError] = useState(false);
    const [signup] = useSignUpMutation()
    const navigate = useNavigate()

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        try {
            const response = await signup(values).unwrap();
            console.log(response)
            navigate('/login')
        } catch (error) {
            console.log(error)
            setError(true)
        }
    }

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setError(false)
        setValues({ ...values, [event.target.name]: event.target.value })
    }

    return (
        <DefaultLayout>
            <Box maxWidth={'50%'} sx={{ display: 'flex', flexDirection: 'column' }}>
                <UserForm error={error} type="signup" onSubmit={handleSubmit} onChange={handleChange} />
            </Box>
        </DefaultLayout>
    )
}