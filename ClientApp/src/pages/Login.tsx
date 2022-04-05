import React, { useState } from "react";
import { Box } from "@mui/material";
import DefaultLayout from "layouts/DefaultLayout";
import UserForm from "components/form/UserForm";
import { useLoginMutation } from "data/foodbApi";
import { useNavigate } from "react-router-dom";
import { IAuthSuccessResponse } from "types";
import { useAppDispatch } from "utils/hooks";
import { setToken } from "data/authSlice";

export default function Login() {
  const [values, setValues] = useState({
    username: "",
    password: "",
  });
  const [error, setError] = useState(false);

  const [login] = useLoginMutation()
  const navigate = useNavigate()
  const dispatch = useAppDispatch()

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await login(values).unwrap();
      console.log(response)
      dispatch(setToken((response as IAuthSuccessResponse)))
      navigate('/')
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
        <UserForm error={error} type="login" onSubmit={handleSubmit} onChange={handleChange} />
      </Box>
    </DefaultLayout>
  )
}