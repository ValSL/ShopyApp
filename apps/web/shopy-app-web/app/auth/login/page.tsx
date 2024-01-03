'use client';

import { SimpleGrid, Box, Title, TextInput, PasswordInput, Button, Group, Stack, Flex, Slider } from "@mantine/core";
import React from 'react';
import classes from "./loginForm.module.css";
import Link from "next/link";
import { z } from "zod";
import { SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useLogin } from "../api/authApi";
import { useRouter } from "next/navigation";
import { RoutesPaths } from "@/app/routes";
import { useQueryClient } from "@tanstack/react-query";

const loginSchema = z.object({
  email: z.string().email().min(1, 'Please, enter your email'),
  password: z.string().min(1, 'Please, enter your name'),
});

type LoginParams = z.infer<typeof loginSchema>;


const LoginPage = () => {
  const router = useRouter();
  const queryClient = useQueryClient();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginParams>({
    resolver: zodResolver(loginSchema),
  });

  const { mutate: loginUser, isPending } = useLogin<LoginParams>();

  const onSubmit: SubmitHandler<LoginParams> = async (data) => {
    loginUser(data, {
      onSuccess: async (response: { data: { token: string; }; }) => {
        queryClient.invalidateQueries({ queryKey: ['user'] });
        localStorage.setItem("access_token", response.data.token);
        router.push(RoutesPaths.ProductList);
      },
    });

  };

  return (

    <Box className={classes.mainContainer}>
      <Box className={classes.login}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Stack gap="1.5rem">

            <Title size="26px">Sign In</Title>

            <Stack gap="1rem">
              <TextInput label="Email" placeholder="Enter Email" {...register("email")} />
              <PasswordInput label="Password" placeholder="Enter password" {...register("password")} />
            </Stack>

            <Button loading={isPending} type="submit" w="100%">Sign in</Button>

            <Group justify="center">Don't have an accont? <Link href="/auth/register">Register</Link></Group>

          </Stack>
        </form>

      </Box>
    </Box>
  );
};

export default LoginPage;