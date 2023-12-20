import type { Metadata } from "next";
import { Inter } from "next/font/google";
import global from "../global.module.css";
import "@mantine/core/styles.css";
import { MantineProvider, ColorSchemeScript, Container } from "@mantine/core";
import { theme } from "../theme";
import MainLayout from "../components/MainLayout";
import Header from "../components/Header";

export default function HomeLayout({ children }: { children: React.ReactNode }) {
	return <MainLayout>{children}</MainLayout>;
}
