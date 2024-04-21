import * as React from "react";
import {
  makeStyles,
  mergeClasses,
  shorthands,
  tokens,
  useId,
  Input,
  Label,
} from "@fluentui/react-components";

const useStyles = makeStyles({
  base: {
    display: "flex",
    flexDirection: "column",
    maxWidth: "400px",
  },
  field: {
    display: "grid",
    gridRowGap: tokens.spacingVerticalXXS,
    marginTop: tokens.spacingVerticalMNudge,
    ...shorthands.padding(tokens.spacingHorizontalMNudge),
  },
  filledLighter: {
    backgroundColor: tokens.colorNeutralBackgroundInverted,
    "> label": {
      color: tokens.colorNeutralForegroundInverted2,
    },
  },
  filledDarker: {
    backgroundColor: tokens.colorNeutralBackgroundInverted,
    "> label": {
      color: tokens.colorNeutralForegroundInverted2,
    },
  },
});

export interface Props {
  placeholder: string
  chageValue: (value: string) => void
  type: "number" | "search" | "time" | "text" | "email" | "password" | "tel" | "url" | "date" | "datetime-local" | "month" | "week"
}

export const VInput = (props: Props) => {
  const outlineId = useId("input-outline");
  const underlineId = useId("input-underline");
  const filledLighterId = useId("input-filledLighter");
  const filledDarkerId = useId("input-filledDarker");
  const styles = useStyles();


  return (
      <div className={styles.field}>
        <Input appearance="outline" id={outlineId} placeholder={props.placeholder} onChange={(e) => {
          props.chageValue(e.target.value)
        }}
        type={props.type}
        />
      </div>
  );
};