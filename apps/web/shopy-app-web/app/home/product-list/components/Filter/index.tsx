'use client'

import React from "react";
import classes from "./filter.module.css";
import { Box, Flex, NumberInput, SimpleGrid, Text, rem } from "@mantine/core";
import { IconX, IconCurrencyDram } from "@tabler/icons-react";
import { useMediaQuery } from "@mantine/hooks";

const Filter = () => {
	const match = useMediaQuery("(max-width: 1024px)");
	const icon = <IconCurrencyDram style={{ width: rem(0), height: rem(0) }} stroke={0} />;
	const from = <Text size="14px">From:</Text>;
	const to = <Text size="14px">To:</Text>;
	return (
		<Box className={classes.filterbox}>
			<SimpleGrid cols={2} spacing={0} className={classes.container}>
				<Text fw="bold" size="20px">
					Filters
				</Text>
				<Flex align="center" className={classes.resetButton} gap={5}>
					<Text size="14px">Reset</Text>
					<IconX size={14} />
				</Flex>

				<Box className={classes.filterContentBox2}>
					<Text fw="bold" size="16px">
						Price
					</Text>
				</Box>
				<NumberInput
					styles={{ section: { marginLeft: "10px" }, input: { paddingLeft: "47px" } }}
					prefix="$"
					style={{ gridRowStart: 5, gridColumn: match ? "span 2" : "" }}
					leftSection={from}
					rightSection={icon}
				/>
				<NumberInput
					styles={{ section: { marginLeft: "2px" }, input: { paddingLeft: "32px" } }}
					style={{ gridRowStart: match ? 7 : 5, gridColumn: match ? "span 2" : "" }}
					prefix="$"
					leftSection={to}
					rightSection={icon}
				/>
			</SimpleGrid>
		</Box>
	);
};

export default Filter;
