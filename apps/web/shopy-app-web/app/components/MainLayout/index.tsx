import React, { PropsWithChildren, ReactNode } from "react";
import Header from "../Header";
import { Container, Flex, SimpleGrid } from "@mantine/core";

const MainLayout = ({ children }: { children: ReactNode }) => {
	return (
		<Container size="90rem">
			<SimpleGrid>
				<Header />
				{children}
			</SimpleGrid>
		</Container>
	);
};

export default MainLayout;
