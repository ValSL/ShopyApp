'use client';

import React from 'react';
import classes from "./registerForm.module.css";
import { Box, Title, TextInput, PasswordInput, Button, Group, Stack, Slider } from "@mantine/core";
import Link from "next/link";
import { z } from "zod";
import { SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useRegister } from "../shared/authApi";

const registerSchema = z.object({
  firstName: z.string().min(1, 'Please, enter your name'),
  lastName: z.string().min(1, 'Please, enter your secondName'),
  email: z.string().email().min(1, 'Please, enter your email'),
  password: z.string().min(1, 'Please, enter your name'),
});

type RegisterParams = z.infer<typeof registerSchema>;

const RegisterPage = () => {

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterParams>({
    resolver: zodResolver(registerSchema),
  });

  const { mutate: registerUser, isPending } = useRegister<RegisterParams>();

  const onSubmit: SubmitHandler<RegisterParams> = (data) => {
    registerUser(data,
      {
        onSuccess: (response: any) => {
          console.log("success");
        },
        onError: (error: any) => {
          console.log("error");
        }
      });
  };

  return (
    <Box className={classes.mainContainer}>
      <Box className={classes.register}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Stack gap="1.5rem">


            <Title size="26px">Sign Up</Title>

            <Stack gap="1rem">
              <TextInput label="First name" placeholder="Enter first name" {...register("firstName")} error={errors.firstName?.message} />
              <TextInput label="Last name" placeholder="Enter last name" {...register("lastName")} error={errors.lastName?.message} />
              <TextInput label="Email" placeholder="Enter Email" {...register("email")} error={errors.email?.message} />
              <PasswordInput label="Password" placeholder="Enter password" {...register("password")} error={errors.password?.message} />
            </Stack>

            <Button type="submit" w="100%">Create account</Button>

            <Group justify="center">Have an accont? <Link href="/auth/login">Sign in</Link></Group>

          </Stack>
        </form>
      </Box>
    </Box>
  );
};

export default RegisterPage;