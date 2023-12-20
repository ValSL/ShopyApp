import React from 'react';
import classes from "./registerForm.module.css";
import { SimpleGrid, Box, Title, TextInput, PasswordInput, Button, Group, Stack } from "@mantine/core";
import Link from "next/link";

const RegisterPage = () => {
  return (
    <Box className={classes.mainContainer}>
      <Box className={classes.register}>
        <Stack gap="1.5rem">

          <Title size="26px">Sign Up</Title>

          <Stack gap="1rem">
            <TextInput label="First name" placeholder="Enter first name" />
            <TextInput label="Last name" placeholder="Enter last name" />
            <TextInput label="Email" placeholder="Enter Email" />
            <PasswordInput label="Password" placeholder="Enter password" />
          </Stack>

          <Button w="100%">Create account</Button>

          <Group justify="center">Have an accont? <Link href="/auth/login">Sign in</Link></Group>
        
        </Stack>

      </Box>
    </Box>
  );
};

export default RegisterPage;