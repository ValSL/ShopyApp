"use client";

import { Badge, Flex, NavLink, SimpleGrid, Text } from "@mantine/core";
import React, { useState } from "react";
import BlockSVG from "./components/BlockSvg";
import CartSVG from "./components/CartSvg";
import ExitSVG from "./components/ExitSvg";
import classes from "./header.module.css";
import { useRouter } from "next/navigation";


const data = [{ label: "Marketplace", href: '/' }, { label: "Your Products", href: '/home/user-products' }];

const Header = () => {
	const [active, setActive] = useState(0);
	const router = useRouter();

	const items = data.map((item, index) => (
		<NavLink
			key={item.label}
			active={index === active}
			label={item.label}
			onClick={() => {
				setActive(index);
				router.push(item.href);
			}}
			classNames={{
				root: classes.navLinkRoot,
				body: classes.navLinkBody,
			}}
		/>
	));

	return (
		<Flex className={classes.header} align="center" justify="space-between">
			<Flex className={classes.logoBlock} align="center" gap="0.5rem" onClick={() => router.push('/')}>
				<Badge color="red" size="" />
				<BlockSVG />
				<Text className="hover:cursor-pointer" fw="bold" onClick={() => console.log("qqqqq")}>
					Shopy
				</Text>
			</Flex>
			<SimpleGrid cols={2}>{items}</SimpleGrid>
			<Flex gap={32} align="center">
				<CartSVG />
				<ExitSVG />
			</Flex>
		</Flex>
	);
};

export default Header;
