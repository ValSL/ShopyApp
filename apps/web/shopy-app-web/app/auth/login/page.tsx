import { SimpleGrid, Box, Title, TextInput, PasswordInput, Button, Group, Stack, Flex } from "@mantine/core";
import React from 'react';
import classes from "./loginForm.module.css";
import Link from "next/link";

const LoginPage = () => {
    return (
        <Box className={classes.mainContainer}>
            <Box className={classes.login}>
                <Stack gap="1.5rem">
                   
                    <Title size="26px">Sign In</Title>

                    <Stack gap="1rem">
                        <TextInput label="Email" placeholder="Enter Email" />
                        <PasswordInput label="Password" placeholder="Enter password" />
                    </Stack>

                    <Button w="100%">Sign in</Button>

                    <Group justify="center">Don't have an accont? <Link href="/auth/register">Register</Link></Group>
                
                </Stack>
            </Box>
        </Box>
    );
};

export default LoginPage;