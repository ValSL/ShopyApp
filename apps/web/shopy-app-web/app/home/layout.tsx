import "@mantine/core/styles.css";
import MainLayout from "../components/MainLayout";

export default function HomeLayout({ children }: { children: React.ReactNode }) {
	return <MainLayout>{children}</MainLayout>;
}
