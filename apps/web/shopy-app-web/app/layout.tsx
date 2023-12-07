import type { Metadata } from "next";
import { Inter } from "next/font/google";
import global from "./global.module.css";
import "@mantine/core/styles.css";
import { MantineProvider, ColorSchemeScript, Container } from "@mantine/core";
import { theme } from "./theme";
import MainLayout from "./components/MainLayout";
import Header from "./components/Header";

export const metadata: Metadata = {
	title: "Create Next App",
	description: "Generated by create next app",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
	return (
		<html lang="en">
			<head>
				<ColorSchemeScript />
			</head>
			<body className={global.body}>
				<MantineProvider theme={theme}>
					<MainLayout>{children}</MainLayout>
					{/* {children} */}
				</MantineProvider>
			</body>
		</html>
	);
}
